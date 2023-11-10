using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishStats : MonoBehaviour
{
    public bool _boss;

    public float _healt;

    JellyFish _system;

    private void Start()
    {
        _system = GameObject.Find("Keep").GetComponent<JellyFish>();
    }

    public void TakeDamage(int _damage)
    {
        _healt -= _damage;

        if(_healt <= 0)
        {
            if(_boss)
            {
                _system.Kill(true);
            }

            else
            {
                _system.Kill(false);
            }

            Destroy(gameObject);
        }
    }
}
