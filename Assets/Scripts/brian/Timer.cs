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
            int _lastAmmo = PlayerPrefs.GetInt("Shots");

            if (_lastTime > _backTime)
            {
                PlayerPrefs.SetFloat("BackTime", _backTime);
                PlayerPrefs.SetString("Time", _min.ToString() + "." + _sec.ToString() + "." + _msec.ToString());

                //Debug.Log(PlayerPrefs.GetString("Time"));
                //Debug.Log(PlayerPrefs.GetFloat("BackTime"));
            }

            if (_lastAmmo > _shots)
            {
                PlayerPrefs.SetInt("Shots", _shots);

                //Debug.Log(PlayerPrefs.GetInt("Shots"));
            }

            enabled = false;


            SceneManager.LoadScene(0);
        }
    }
}
