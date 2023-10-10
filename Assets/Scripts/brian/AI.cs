using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    //heal
    public int _health;

    //navmesh
    NavMeshAgent _agent;

    GameObject[] _loc;
    int _index;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        _loc = GameObject.FindGameObjectsWithTag("WaitPoint");
        NewLocation();
    }

    private void Update()
    {
        if(_health <= 0)
        {
            GameObject.Find("Keep").GetComponent<Wave>().Spawn();
            Destroy(gameObject);
        }

        if (Vector3.Distance(transform.position, _loc[_index].transform.position) < .7f)
        {
            NewLocation();
        }
    }

    void NewLocation()
    {
        _index = Random.Range(0, _loc.Length);
        _agent.destination = _loc[_index].transform.position;
    }

}
