using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{

    public MoveWaypoints current_waypoints;
    private GameObject current_target;
    public float max_speed = 10.0f;
    private float current_speed = 0.0f;
    public bool should_move = true;
    public int waypoint_index = 0;
    private float current_fade = 0.0f;
    public float fade_speed = 1.0f;
    public CarSpawner spawner;
    private bool waiting = true;
    private Material mat;
    public Connection crossing;

    // Start is called before the first frame update
    void Start()
    {
        current_target = current_waypoints.waypoints[0];
        Physics.IgnoreLayerCollision(9, 9);
        mat = GetComponentInChildren<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Color color = mat.color;
        color.a = current_fade;
        mat.color = color;

        if (should_move)
        {
            if(waiting)
            {
                FadeIn();
            }
            else
            {
                MoveCar();
            }
        }
    }

    public void MoveCar()
    {
        int end_index = current_waypoints.waypoints.Count - 1;
        int con_index = current_waypoints.waypoints.Count - 2;
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 3, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3.0f))
        {
            if(hit.collider.gameObject.tag == "Car")
            {
                return;
            }
        }

        if (current_target == current_waypoints.waypoints[end_index])
        {
            if ((Vector3.Distance(transform.position, current_target.transform.position) < 0.5f))
            {
                FadeAway();
                return;
            }
            else
            {
                current_target = current_waypoints.waypoints[waypoint_index];
                transform.Translate(Vector3.forward * max_speed * Time.deltaTime);
                Vector3 target_direction = (current_target.transform.position - transform.position).normalized;
                transform.rotation = Quaternion.LookRotation(target_direction);
            }
        }
        else if(current_target == current_waypoints.waypoints[con_index])
        {
            if ((Vector3.Distance(transform.position, crossing.transform.position) < 3.5f))
            {
                if(crossing.crossable == false)
                {
                    waypoint_index++;
                    current_target = current_waypoints.waypoints[waypoint_index];
                }
            }
            else
            {
                transform.Translate(Vector3.forward * max_speed * Time.deltaTime);
                Vector3 target_direction = (current_target.transform.position - transform.position).normalized;
                transform.rotation = Quaternion.LookRotation(target_direction);
            }
        }
        else
        {
            current_target = current_waypoints.waypoints[waypoint_index];
            if ((Vector3.Distance(transform.position, current_target.transform.position) < 3.5f))
            {
                waypoint_index++;
            }
            transform.Translate(Vector3.forward * max_speed * Time.deltaTime);
            Vector3 target_direction = (current_target.transform.position - transform.position).normalized;

            transform.rotation = Quaternion.LookRotation(target_direction);
        }
    }

    private void FadeAway()
    {
        current_fade -= fade_speed * Time.deltaTime;

        if (current_fade <= 0.0f)
        {
            spawner.RemoveCar(gameObject);
            current_fade = 0.0f;
        }
    }

    private void FadeIn()
    {

        current_fade += fade_speed * Time.deltaTime;
        if (current_fade >= 1.0f)
        {
            current_fade = 1.0f;
            waiting = false;
        }
    }

    public void ResetValues()
    {
        waiting = true;
        waypoint_index = 0;
    }
}
