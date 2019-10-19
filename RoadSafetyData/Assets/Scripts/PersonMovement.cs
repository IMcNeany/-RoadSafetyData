using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public MoveWaypoints current_waypoints;
    private GameObject current_target;
    public bool waiting = false;
    private int connection_index = 0;
    private bool fading = false;
    // Start is called before the first frame update
    void Start()
    {
        current_target = current_waypoints.waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        MovePerson();
    }

    private void MovePerson()
    {
        if(!waiting)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            Vector3 target_direction = (current_target.transform.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(target_direction);
            int final_point = current_waypoints.waypoints.Count - 1;
            if (current_target == current_waypoints.waypoints[final_point])
            {
                if ((Vector3.Distance(transform.position, current_target.transform.position) < 0.5f))
                {
                    FadeAway();
                }
            }
            else
            {
                if ((Vector3.Distance(transform.position, current_target.transform.position) < 0.5f))
                {
                    connection_index++;
                }
                current_target = current_waypoints.waypoints[connection_index];
            }
        }
    }

    private void FadeAway()
    {
        waiting = true;
        //fade away at the end of the path
    }

    private void FadeIn()
    {
        //fade in at start of path
    }
}
