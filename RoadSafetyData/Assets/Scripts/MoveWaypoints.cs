using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MoveWaypoints : MonoBehaviour
{
    public List<GameObject> waypoints;
    public Connection connection;
    public GameObject connection_start;

    // Start is called before the first frame update
    void Start()
    {
        if(connection)
        {
            for (int i = 0; i < waypoints.Count; i++)
            {
                if (waypoints[i] == connection.connection_1 || waypoints[i] == connection.connection_2)
                {
                    connection_start = waypoints[i];
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints != null)
        {
            for (int i = 0; i < waypoints.Count; i++)
            {
                if (i + 1 != waypoints.Count)
                {
                    Debug.DrawLine(waypoints[i].transform.position, waypoints[i + 1].transform.position, Color.green);
                }
            }
        }
    }
}
