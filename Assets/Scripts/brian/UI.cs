using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UI : MonoBehaviour
{
    private PlayerControlls _playerControlls;

    public bool _game;
    public GameObject _settings;

    private void Awake()
    {
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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void settings(InputAction.CallbackContext context)
    {
        Debug.Log("settings");
        _settings.SetActive(true);
        GameObject.Find("Keep").GetComponent<mouseLock>().LockSwitch();
        GameObject.Find("Keep").GetComponent<Timer>().enabled = false;
        GameObject.Find("Player").GetComponent<Movement>().enabled = false;
        GameObject.Find("Player").GetComponentInChildren<Shoot>().enabled = false;
    }

    public void Exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
