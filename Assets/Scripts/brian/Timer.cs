using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI _text;
    public float _time, _backTime;
    int _msec, _sec, _min;
    public bool _running = true;
    public Leaderboard _leaderboard;

    public int _shots;

    public GameObject _vicrory;
    public TextMeshProUGUI _speed, _ammo;
    private void Update()
    {
        if (_running)
        {
            _time += Time.deltaTime;
            _msec = (int)((_time - _sec) * 100);
            _sec = (int)_time;

            if (_sec == 60 && _msec == 0)
            {
                _time = 0;
                _min += 1;
            }

            _text.text = _min.ToString() + "." + _sec.ToString() + "." + _msec.ToString();
            _backTime += Time.deltaTime;
        }

        if (!_running)
        {
            float _lastTime = PlayerPrefs.GetFloat("BackTime");
            int _lastAmmo = PlayerPrefs.GetInt("BackShots");

            if (_lastTime > _backTime || _lastTime == 0)
            {
                PlayerPrefs.SetFloat("BackTime", _backTime);
                PlayerPrefs.SetString("Time", _min.ToString() + "." + _sec.ToString() + "." + _msec.ToString());

                //Debug.Log(PlayerPrefs.GetString("Time"));
                //Debug.Log(PlayerPrefs.GetFloat("BackTime"));
            }

            if (_lastAmmo > _shots || _lastAmmo == 0)
            {
                PlayerPrefs.SetInt("BackShots", _shots);
                PlayerPrefs.SetString("Shots", _shots.ToString());

                //Debug.Log(PlayerPrefs.GetInt("Shots"));
            }

            enabled = false;

            //victory
            _vicrory.SetActive(true);

            GameObject.Find("Keep").GetComponent<mouseLock>().LockSwitch();
            GameObject.Find("Keep").GetComponent<Timer>().enabled = false;
            GameObject.Find("Player").GetComponent<Movement>().enabled = false;
            GameObject.Find("Player").GetComponentInChildren<Shoot>().enabled = false;

            _speed.text = _min.ToString() + "." + _sec.ToString() + "." + _msec.ToString();
            _ammo.text = _shots.ToString();
        }
    }
}
