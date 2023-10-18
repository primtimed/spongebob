using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int _health;

    public UI _ui;

    public GameObject[] _icons; 

    public void TakeDamage(int _damage)
    {
        _health -= _damage;
        _icons[_health].SetActive(false);


        if (_health <= 0)
        {
            _ui.Lost();
            this.enabled= false;

            Time.timeScale = 0;
        }
    }
}
