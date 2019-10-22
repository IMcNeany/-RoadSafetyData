using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public ObjectPooler OP;
    public MoveWaypoints left_side;
    public MoveWaypoints right_side;
    public List<GameObject> spawn_locations;
    private float current_timer = 0.0f;
    public int max_cars;
    public float spawn_delay = 1.0f;

    private void Start()
    {
        spawn_locations.Add(left_side.waypoints[0]);
        spawn_locations.Add(right_side.waypoints[0]);
    }

    private void Update()
    {
        PopulateWorldWithCars();
    }

    public void PopulateWorldWithCars()
    {
        current_timer += 1 * Time.deltaTime;
        for (int i = 0; i < max_cars; i++)
        {
            if (current_timer > spawn_delay)
            {
                if (OP.object_pool.Count < max_cars)
                {
                    AddCar();
                    current_timer = 0.0f;
                }
                else if (OP.object_pool[i].activeSelf == false)
                {
                    AddCar();
                    current_timer = 0.0f;
                }
            }
        }
    }

    public void AddCar()
    {
        GameObject new_person = OP.GetPooledObject();

        int random = Random.Range(0, 2);
        new_person.transform.position = spawn_locations[random].transform.position;
        new_person.transform.parent = transform;
        CarMovement CM = new_person.GetComponent<CarMovement>();

        switch(random)
        {
            case 0:
                CM.current_waypoints = left_side;
                break;
            case 1:
                CM.current_waypoints = right_side;
                break;
        }

        new_person.SetActive(true);
    }

    public void RemoveCar(GameObject obj)
    {
        for (int i = 0; i < OP.object_pool.Count; i++)
        {
            if (OP.object_pool[i] == obj)
            {
                OP.object_pool[i].SetActive(false);
            }
        }
    }


}
