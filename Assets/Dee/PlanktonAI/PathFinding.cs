using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinding : MonoBehaviour
{
    NavMeshAgent agent007;

    //array of different poi's 
    //interger to pick poi

    public Transform[] wayPoint;
    int waypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        agent007 = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, wayPoint[waypointIndex].transform.position) < 2)
        {
            chooseWayPoint();
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        //choose with randomizer wich waypoint to go to
        agent007.SetDestination(wayPoint[waypointIndex].transform.position); 
    }
    void chooseWayPoint()
    {
        waypointIndex++;
        if(waypointIndex == wayPoint.Length)
        {
            waypointIndex = 0;
        }
    }
}
