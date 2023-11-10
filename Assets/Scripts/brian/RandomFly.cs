using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFly : MonoBehaviour
{
    public float _swimSpeed;
    public int _rotateChange;

    Transform _transform;
    Rigidbody _rb;

    private void Start()
    {
        _transform= GetComponent<Transform>();
        _rb = GetComponent<Rigidbody>();

        SwimRandomly();
    }

    private void Update()
    {
        int _random = Random.Range(0, _rotateChange);

        if(_random == 0)
        {
            SwimRandomly();
        }
    }

    private void SwimRandomly()
    {
        Vector3 randomVelocity = new Vector3(Random.Range(-_swimSpeed, _swimSpeed), Random.Range(-_swimSpeed, _swimSpeed), Random.Range(-_swimSpeed, _swimSpeed));
        _rb.velocity = randomVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        SwimRandomly();
    }
}