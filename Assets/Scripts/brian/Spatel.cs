using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spatel : MonoBehaviour
{
    Rigidbody _rb;

    float _timer;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _rb.AddForce(transform.forward * 50, ForceMode.Force);
    }

    private void Update()
    {
        transform.Rotate(3, 0, 0);

        _timer += Time.deltaTime;

        if(_timer > 3)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("hit");
        }

        Destroy(gameObject);
    }
}
