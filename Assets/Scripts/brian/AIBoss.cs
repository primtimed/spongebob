using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class AIBoss : MonoBehaviour
{
    public int _health;
    GameObject[] _table;
    int _index;

    GameObject _target, _aim;

    public GameObject _weapon;

    private void Start()
    {
        _target = GameObject.Find("Player");
        _aim = GameObject.Find("Aim");
        _table = GameObject.FindGameObjectsWithTag("BossPoint");

        _index = Random.Range(0, _table.Length);
        transform.position = _table[_index].transform.position;
        OnEnable();
    }

    private void OnEnable()
    {
        StartCoroutine(NewLocation());
    }

    public void OnDisable()
    {
        StopAllCoroutines();
    }

    void Update()
    {
        transform.LookAt(_target.transform.position);

        if(_health <= 0)
        {
            Destroy(gameObject);
            GameObject.Find("Keep").GetComponent<Wave>().Victory();
        }
    }

    public IEnumerator NewLocation()
    {
        Debug.Log("new");
        Instantiate(_weapon, _aim.transform.position, transform.rotation);
        _index = Random.Range(0, _table.Length);
        transform.position = _table[_index].transform.position;
        yield return new WaitForSeconds(Random.Range(1,3));
        StartCoroutine(NewLocation());
    }
}
