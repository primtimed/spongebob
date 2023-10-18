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
    public TextMeshProUGUI _speed, _ammo, _speedL;

    public UI _ui;
    private GameMode _gameMode;

    private void Start()
    {
        _gameMode = GameObject.Find("Keep").GetComponent<GameMode>();
    }
    private void Update()
    {
        if (_running)
        {
            _time += Time.deltaTime;
            _msec = (int)((_time - _sec) * 100);
            _sec = (int)_time;

            if (_sec >= 60)
            {
                _time -= 60;
                _min += 1;
            }

            _text.text = _min.ToString() + "." + _sec.ToString() + "." + _msec.ToString();
            _backTime += Time.deltaTime;

            if (_backTime > 300)
            {
                _text.text = "5.00.00";
                _ui.TimeOver();
            }
        }

        if (!_running)
        {
            if (_gameMode._mode == GameMode.Mode.WaveCrabs)
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

                _ui.Victory();

                _speed.text = _min.ToString() + "." + _sec.ToString() + "." + _msec.ToString();
                _ammo.text = _shots.ToString();
            }

            else if (_gameMode._mode == GameMode.Mode.spongebobHome)
            {
                float _lastTime = PlayerPrefs.GetFloat("BackTime_spons");
                int _lastAmmo = PlayerPrefs.GetInt("BackShots_spons");

                if (_lastTime > _backTime || _lastTime == 0)
                {
                    PlayerPrefs.SetFloat("BackTime_spons", _backTime);
                    PlayerPrefs.SetString("Time_spons", _min.ToString() + "." + _sec.ToString() + "." + _msec.ToString());

                    //Debug.Log(PlayerPrefs.GetString("Time"));
                    //Debug.Log(PlayerPrefs.GetFloat("BackTime"));
                }

                if (_lastAmmo > _shots || _lastAmmo == 0)
                {
                    PlayerPrefs.SetInt("BackShots_spons", _shots);
                    PlayerPrefs.SetString("Shots_spons", _shots.ToString());

                    //Debug.Log(PlayerPrefs.GetInt("Shots"));
                }

                enabled = false;

                _ui.Victory();

                _speed.text = _min.ToString() + "." + _sec.ToString() + "." + _msec.ToString();
                _ammo.text = _shots.ToString();
            }

            else if(_gameMode._mode == GameMode.Mode.OneShot)
            {
                float _lastTime = PlayerPrefs.GetFloat("BackTime_OneShot");

                if (_lastTime > _backTime || _lastTime == 0)
                {
                    PlayerPrefs.SetFloat("BackTime_OneShot", _backTime);
                    PlayerPrefs.SetString("Time_OneShot", _min.ToString() + "." + _sec.ToString() + "." + _msec.ToString());

                    //Debug.Log(PlayerPrefs.GetString("Time"));
                    //Debug.Log(PlayerPrefs.GetFloat("BackTime"));
                }

                enabled = false;

                _ui.Victory();

                _speed.text = _min.ToString() + "." + _sec.ToString() + "." + _msec.ToString();
            }
        }
    }

    public void Lost()
    {
        _speedL.text = _min.ToString() + "." + _sec.ToString() + "." + _msec.ToString();
    }
}
