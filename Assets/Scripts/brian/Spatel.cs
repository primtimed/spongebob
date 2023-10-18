using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spatel : MonoBehaviour
{
    Rigidbody _rb;

    float _timer;
    public float _rotateSpeed;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _rb.AddForce(transform.forward * 125, ForceMode.Force);
    }

    private void Update()
    {
        transform.Rotate(_rotateSpeed, 0, 0);

        _timer += Time.deltaTime;

        if(_timer > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("hit");
            other.GetComponent<PlayerStats>().TakeDamage(1);
        }

        Destroy(gameObject);
    }
}
