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
    // Start is called before the first frame update
    void Start()
    {
        current_target = current_waypoints.waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(should_move)
        {
            MoveCar();
        }
    }

    public void MoveCar()
    {
        int end_index = current_waypoints.waypoints.Count - 1;

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

    public void FadeAway()
    {

    }

    public void FadeIn()
    {

    }
}
