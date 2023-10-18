using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    private PlayerControlls _playerControlls;

    public bool _game;
    public GameObject _settings;

    public GameObject _lost, _victory, _lostT;

    public TextMeshProUGUI _speed, _ammo;

    private void Awake()
    {
        Time.timeScale= 1.0f;
        if (_game == true)
        {
            _playerControlls = new PlayerControlls();
        }
    }

    private void OnEnable()
    {
        if (_game == true)
        {
            _playerControlls.DeafultMovement.Esc.started += settings;
            _playerControlls.Enable();
        }
    }

    private void OnDisable()
    {
        if (_game == true)
        {
            _playerControlls.Disable();
        }
    }

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
    }

    public void StartAi()
    {
        Time.timeScale = 1;
    }

    public void settings(InputAction.CallbackContext context)
    {
        if (!_settings.active)
        {
            GameObject.Find("Keep").GetComponent<mouseLock>().LockSwitch();
            Debug.Log("settings");
            _settings.SetActive(true);


            GameObject.Find("Keep").GetComponent<Timer>().enabled = false;
            GameObject.Find("Player").GetComponent<Movement>().enabled = false;
            GameObject.Find("Player").GetComponentInChildren<Shoot>().enabled = false;

            Time.timeScale = 0;
        }
    }

    public void Exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }

    public void StatsReste()
    {
        if (GameObject.Find("GameModes").GetComponent<ScoreSwitch>()._dropDown.value == 0)
        {
            PlayerPrefs.SetFloat("BackTime", 0);
            PlayerPrefs.SetString("Time", null);

            PlayerPrefs.SetInt("BackShots", 0);
            PlayerPrefs.SetString("Shots", null);
        }

        else if (GameObject.Find("GameModes").GetComponent<ScoreSwitch>()._dropDown.value == 1)
        {
            PlayerPrefs.SetFloat("BackTime_spons", 0);
            PlayerPrefs.SetString("Time_spons", null);

            PlayerPrefs.SetInt("BackShots_spons", 0);
            PlayerPrefs.SetString("Shots_spons", null);
        }

        else if (GameObject.Find("GameModes").GetComponent<ScoreSwitch>()._dropDown.value == 2)
        {
            PlayerPrefs.SetFloat("BackTime_OneShot", 0);
            PlayerPrefs.SetString("Time_OneShot", null);
        }
    }

    public void Lost()
    {
        _lost.SetActive(true);

        GameObject.Find("Keep").GetComponent<mouseLock>().LockSwitch();

        GameObject.Find("Keep").GetComponent<Timer>().Lost();
        GameObject.Find("Keep").GetComponent<Timer>().enabled = false;
        GameObject.Find("Player").GetComponent<Movement>().enabled = false;
        GameObject.Find("Player").GetComponentInChildren<Shoot>().enabled = false;

        Time.timeScale = 0;
    } 
    
    public void TimeOver()
    {
        _lostT.SetActive(true);

        GameObject.Find("Keep").GetComponent<mouseLock>().LockSwitch();

        GameObject.Find("Keep").GetComponent<Timer>().enabled = false;
        GameObject.Find("Player").GetComponent<Movement>().enabled = false;
        GameObject.Find("Player").GetComponentInChildren<Shoot>().enabled = false;

        Time.timeScale = 0;
    }
    
    public void Victory()
    {
        _victory.SetActive(true);

        GameObject.Find("Keep").GetComponent<mouseLock>().LockSwitch();
        GameObject.Find("Keep").GetComponent<Timer>().enabled = false;
        GameObject.Find("Player").GetComponent<Movement>().enabled = false;
        GameObject.Find("Player").GetComponentInChildren<Shoot>().enabled = false;
    }

    public void FullScreen()
    {
        if (!Screen.fullScreen)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }

        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    public void ScreenRes(GameObject _obj)
    {
        Debug.Log(_obj.GetComponent<TMP_Dropdown>().value);

        if (_obj.GetComponent<TMP_Dropdown>().value == 0)
        {
            if(Screen.fullScreen)
            {
                Screen.SetResolution(1280, 720, true);
            }

            else
            {
                Screen.SetResolution(1280, 720, false);
            }
        }

        else if(_obj.GetComponent<TMP_Dropdown>().value == 1)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(1920, 1080, true);
            }

            else
            {
                Screen.SetResolution(1920, 1080, false);
            }
        }

        else if (_obj.GetComponent<TMP_Dropdown>().value == 2)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(2560, 1440, true);
            }

            else
            {
                Screen.SetResolution(2560, 1440, false);
            }
        }

        else if (_obj.GetComponent<TMP_Dropdown>().value == 3)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(3840, 2160, true);
            }

            else
            {
                Screen.SetResolution(3840, 2160, false);
            }
        }
    }
}
