using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Connection : MonoBehaviour
{
    public GameObject connection_1;
    public GameObject connection_2;

    void Update()
    {
        if(connection_1 && connection_2)
        {
            Debug.DrawLine(connection_1.transform.position, connection_2.transform.position, Color.cyan);
        }
    }
}
