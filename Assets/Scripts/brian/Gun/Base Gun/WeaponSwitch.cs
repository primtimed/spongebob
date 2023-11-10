using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitch : MonoBehaviour
{
    PlayerControlls _playerControlls;
    InputAction _weapon1, _weapon2;

    public GameObject _weaponAr, _weaponShotgun;


    private void Awake()
    {
        _playerControlls = new PlayerControlls();
    }

    private void OnEnable()
    {
        _playerControlls.Enable();

        _weapon1 = _playerControlls.DeafultMovement.Weapon1;
        _weapon1.started += Weapon1; 

        _weapon2 = _playerControlls.DeafultMovement.Weapon2;
        _weapon2.started += Weapon2;
    }

    private void OnDisable()
    {
        _playerControlls.Disable();
    }

    void Weapon1(InputAction.CallbackContext context)
    {
        _weaponAr.SetActive(true);
        _weaponShotgun.SetActive(false);
    }

    void Weapon2(InputAction.CallbackContext context)
    {
        _weaponAr.SetActive(false);
        _weaponShotgun.SetActive(true);
    }
}
