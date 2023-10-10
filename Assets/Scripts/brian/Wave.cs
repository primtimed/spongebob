using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wave : MonoBehaviour
{
    public int _maxWave;
    public GameObject _plankton, _boss;
    int _wave;

    GameObject[] _loc;

    private void Start()
    {
        _loc = GameObject.FindGameObjectsWithTag("WaitPoint");
        Spawn();
    }

    public void Spawn()
    {
        if(_wave <= _maxWave)
        {
            Plankton();
        }
        else
        {
            Boss();
        }
    }

    void Plankton()
    {
        _wave++;
        Instantiate(_plankton, _loc[Random.Range(0, _loc.Length)].transform.position, transform.rotation);
    }

    void Boss()
    {
        Instantiate(_boss);
    }

    public void Victory()
    {
        GetComponent<Timer>()._running = false;
    }
}
