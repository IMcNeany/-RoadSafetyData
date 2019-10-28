using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLights : MonoBehaviour
{
    public List<Light> lights;
    public float switch_time = 5.0f;
    private float yellow_delay = 4.0f;
    private float current_time = 0.0f;
    public bool switched = true;
    public Connection crossing;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        current_time += 1 * Time.deltaTime;
        if(current_time > yellow_delay && current_time < switch_time)
        {
            for (int i = 0; i < lights.Count; i++)
            {
                lights[i].color = Color.yellow;
            }
        }
        else if (current_time > switch_time)
        {
            current_time = 0.0f;
            switched = !switched;

            if (switched)
            {
                crossing.crossable = true;
                for (int i = 0; i < lights.Count; i++)
                {
                    lights[i].color = Color.red;
                }
            }
            else
            {
                crossing.crossable = false;
                for (int i = 0; i < lights.Count; i++)
                {
                    lights[i].color = Color.green;
                }
            }
        }
    }
}
