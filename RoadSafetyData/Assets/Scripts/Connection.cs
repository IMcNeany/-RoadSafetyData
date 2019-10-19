using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Connection : MonoBehaviour
{
    public GameObject connection_1;
    public GameObject connection_2;
    public MoveWaypoints way_points1;
    public MoveWaypoints way_points2;
    public bool crossable = false;

    void Update()
    {
        if(connection_1 && connection_2)
        {
            Debug.DrawLine(connection_1.transform.position, connection_2.transform.position, Color.cyan);
        }
    }

    public GameObject GetNextConnection(GameObject first_connection)
    {
        if(first_connection == connection_1)
        {
            return connection_2;
        }
        else
        {
            return connection_1;
        }
    }
}
