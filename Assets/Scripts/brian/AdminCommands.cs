using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class AdminCommands : MonoBehaviour
{
    private PlayerControlls _playerControlls;

    private void Awake()
    {
        _playerControlls = new PlayerControlls();
    }

    private void OnEnable()
    {
        _playerControlls.Enable();

        _playerControlls.Commands.TimeSwitch.started += TimeSwitch;

        _playerControlls.Commands.SkipWave.started += SkipWave;

        _playerControlls.Commands.Damage.started += Damage;

        _playerControlls.Commands.AimBot.started += AimBot;
        _playerControlls.Commands.AimBot.canceled += AimBot;
    }

    private void OnDisable()
    {
        _playerControlls.Disable();
    }

    void TimeSwitch(InputAction.CallbackContext context)
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 10;
        }

        else if(Time.timeScale == 10)
        {
            Time.timeScale = 1;
        }

        else
        {

        }
    }

    void SkipWave(InputAction.CallbackContext context)
    {
        GameObject.Find("plankton(Clone)").GetComponent<AI>()._health = -10;
    }

    void Damage(InputAction.CallbackContext context)
    {
        GameObject.Find("Player").GetComponent<PlayerStats>().TakeDamage(1);
    }

    void AimBot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //print("Aimbot");
            GameObject _enemy = GameObject.Find("plankton(Clone)");
        }

        else if (context.canceled)
        {
            //print("AimbotC");
        }
    }
}
