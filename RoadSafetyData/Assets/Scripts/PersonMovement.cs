﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public float fade_speed = 0.5f;
    private float current_fade = 0.0f;
    public MoveWaypoints current_waypoints;
    public Connection current_connection;
    public GameObject connection_start;
    public GameObject connection_end;
    public bool waiting = false;
    public GameObject current_target;
    public int waypoint_index = 0;
    private Animator animator;
    public bool crossed = false;
    public bool direction = true; //random forward/backward
    private bool should_cross; //random if person should try to cross?
    public PeopleSpawner spawner;
    public bool stop_moving = false;
    private Collider this_collider;
    private bool hit = false;
    private Material mat;

    void Start()
    {
        mat = GetComponentInChildren<MeshRenderer>().material;
        this_collider = GetComponent<Collider>();
        animator = GetComponentInChildren<Animator>();
        ResetValues();
        Physics.IgnoreLayerCollision(8, 8);
    }

    void Update()
    {
        Color color = mat.color;
        color.a = current_fade;
        mat.color = color;

        if(!stop_moving)
        {
            if (!waiting)
            {
                MovePerson();
            }
            else
            {
                FadeIn();
            }
        }
        else
        {
            animator.SetBool("Moving", false);
            
        }

        if(hit)
        {
            FadeAway();
        }
        
    }

    public void ResetValues()
    {
        should_cross = (Random.value > 0.5f);
        if (current_waypoints)
        {
            if (current_waypoints.connection)
            {
                current_connection = current_waypoints.connection;
                connection_start = current_waypoints.connection_start;
            }
        }
        crossed = false;
        waiting = true;
        hit = false;
    }


    //yeah I know this is confusing.
    private void MovePerson()
    {
        int end_index = current_waypoints.waypoints.Count - 1;
        int start_index = 0;

        //start and end of waypoints, have the character fade in or out
        if (current_target == current_waypoints.waypoints[end_index] && crossed)
        {
            if ((Vector3.Distance(transform.position, current_target.transform.position) < 0.5f))
            {
                FadeAway();
                return;
            }
        }
        else if(current_target == current_waypoints.waypoints[start_index] && crossed)
        {
            if ((Vector3.Distance(transform.position, current_target.transform.position) < 0.5f))
            {
                FadeAway();
                return;
            }
        }
        else
        {
            //move character toward waypoints, if a waypoint is a connection, decide if character should cross
            if ((Vector3.Distance(transform.position, current_target.transform.position) < 0.5f))
            {
                if(current_target == connection_start && crossed == false)
                {
                    if (should_cross)
                    {
                        crossed = true; //use this so stop crossing and continue walking on same side
                        return;
                    }
                    if (current_connection.crossable)
                    {
                        connection_end = current_connection.GetNextConnection(connection_start);
                        current_target = connection_end;
                    }
                    else
                    {
                        animator.SetBool("Moving", false);
                        return;
                    }
                }
                else
                {
                    //chooses which side character should go after crossing
                    if(current_target == connection_end && crossed == false)
                    {
                        crossed = true;
                        if (current_waypoints == current_connection.way_points1)
                        {
                            current_waypoints = current_connection.way_points2;
                        }
                        else
                        {
                            current_waypoints = current_connection.way_points1;
                        }
                        current_target = current_waypoints.waypoints[waypoint_index];
                        direction = (Random.value > 0.5f);
                    }
                    else
                    {
                        if(direction)
                        {
                            waypoint_index++;
                        }
                        else
                        {
                            waypoint_index--;
                        }
                        current_target = current_waypoints.waypoints[waypoint_index];
                    }
                }
            }
        }
        animator.SetBool("Moving", true);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Vector3 target_direction = (current_target.transform.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(target_direction);
    }

    //fade away at the end of the path
    private void FadeAway()
    {
        animator.SetBool("Moving", false);
        current_fade -= fade_speed * Time.deltaTime;

        if(current_fade <= 0.0f)
        {
            spawner.RemovePerson(gameObject);
            current_fade = 0.0f;
        }
    }
    //fade in at start of path
    private void FadeIn()
    {
        animator.SetBool("Moving", false);
        current_fade += fade_speed * Time.deltaTime;
        if (current_fade >= 1.0f)
        {
            waiting = false;
            current_fade = 1.0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Car" && hit == false)
        {
            stop_moving = true;
            hit = true;
            this_collider.enabled = false;
        }
    }
}
