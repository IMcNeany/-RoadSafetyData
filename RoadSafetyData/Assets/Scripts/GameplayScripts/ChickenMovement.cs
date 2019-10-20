using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChickenMovement : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private Queue<Vector3> pathPoints = new Queue<Vector3>();

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        FindObjectOfType<ChickenPathDrawer>().OnNewPathCreated += SetPoints;
    }

    private void SetPoints(IEnumerable<Vector3> points)
    {
        pathPoints = new Queue<Vector3>(points);
    }

    void Update()
    {
        UpdatePathing();
    }

    private void UpdatePathing()
    {
        if (ShouldSetDestination())
        {
            navMeshAgent.SetDestination(pathPoints.Dequeue());
        }
    }

    private bool ShouldSetDestination()
    {
        if (pathPoints.Count == 0)
            return false;

        if (navMeshAgent.hasPath == false || navMeshAgent.remainingDistance < 0.5f)
            return true;

        return false;
    }
}
