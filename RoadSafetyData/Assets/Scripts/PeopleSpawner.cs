using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawner : MonoBehaviour
{
    public MoveWaypoints side_1;
    public MoveWaypoints side_2;
    public List<GameObject> spawn_locations;
    public ObjectPooler OP;
    public int max_people;
    public float spawn_delay = 0.25f;
    private float current_timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        spawn_locations.Add(side_1.waypoints[0]);
        spawn_locations.Add(side_1.waypoints[side_1.waypoints.Count - 1]);
        spawn_locations.Add(side_2.waypoints[0]);
        spawn_locations.Add(side_2.waypoints[side_2.waypoints.Count - 1]);
        //spawn_locations.Add(side_3.waypoints[0]);
        //spawn_locations.Add(side_4.waypoints[0]);
        
    }

    void Update()
    {
        PopulateWorld();
    }

    //fill the world over time till it reaches max_people amount, then continue adding new ones who leave area
    public void PopulateWorld()
    {
        current_timer += 1 * Time.deltaTime;
        for (int i = 0; i < max_people; i++)
        {
            if (current_timer > spawn_delay)
            {
                if (OP.object_pool.Count < max_people)
                {
                    AddPerson();
                    current_timer = 0.0f;
                }
                else if (OP.object_pool[i].activeSelf == false)
                {
                    AddPerson();
                    current_timer = 0.0f;
                }
            }
        }
    }

    public void RemovePerson(GameObject obj)
    {
        for(int i = 0; i < OP.object_pool.Count; i++)
        {
            if(OP.object_pool[i] == obj)
            {
                OP.object_pool[i].SetActive(false);
            }
        }
    }

    public void AddPerson()
    {
        GameObject new_person = OP.GetPooledObject();

        int random = Random.Range(0, 4);
        new_person.transform.position = spawn_locations[random].transform.position;
        new_person.transform.parent = transform;
        PersonMovement PM = new_person.GetComponent<PersonMovement>();
        PM.current_waypoints = spawn_locations[random].GetComponentInParent<MoveWaypoints>();
        PM.current_target = spawn_locations[random];
        PM.spawner = this;
        switch (random)
        {
            case 0:
                PM.waypoint_index = 0;
                PM.direction = true;
                break;
            case 1:
                PM.waypoint_index = PM.current_waypoints.waypoints.Count - 1;
                PM.direction = false;
                break;
            case 2:
                PM.waypoint_index = 0;
                PM.direction = true;
                break;
            case 3:
                PM.waypoint_index = PM.current_waypoints.waypoints.Count - 1;
                PM.direction = false;
                break;
        }
        PM.ResetValues();
        new_person.SetActive(true);
    }
}
