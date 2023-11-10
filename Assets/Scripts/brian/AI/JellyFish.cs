using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFish : MonoBehaviour
{
    public int _toKill;
    public int _kills;

    public GameObject _boss;

    public Transform Spawn;

    public void Kill(bool _finale)
    {
        _kills++;

        if (_toKill == _kills)
        {
            Instantiate(_boss, Spawn);
        }

        if (_finale)
        {
            GetComponent<Timer>()._running = false;
        }
    }
}
