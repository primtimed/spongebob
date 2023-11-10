using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Animator _anime;
    public float _sens, _moveSpeed;

    private PlayerControlls _playerControlls;

    private InputAction _move, _look;
    private Vector2 _moveV2, _rotateV2; 

    private float _x, _y;
    private Rigidbody _rb;

    [Serializable]
    public class Back
    {
        public GameObject _cam;
    }

    public Back _back;

    private void Awake()
    {
        _playerControlls = new PlayerControlls();
    }

    private void OnEnable()
    {
        _move = _playerControlls.DeafultMovement.Movement;  
        _move.Enable();

        _look = _playerControlls.DeafultMovement.Rotation;
        _look.Enable();
    }

    private void OnDisable()
    {
        _move.Disable();
        _look.Disable();
    }


    private void Start()
    {
        _back._cam = GetComponentInChildren<Camera>().gameObject;
        _rb = GetComponentInChildren<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Rotation(_look.ReadValue<Vector2>());
    }

    public void Move()
    {
        _moveV2 = _move.ReadValue<Vector2>();
        _moveV2 = _moveV2.normalized;

        transform.Translate(new Vector3(_moveV2.x, 0, _moveV2.y) * (_moveSpeed * Time.deltaTime));
    }

    public void Rotation(Vector2 _rotateV2)
    {
        float _xB = _rotateV2.x * _sens;
        float _yB = _rotateV2.y * _sens;

        _x += _xB;
        _y -= _yB;

        _y = Mathf.Clamp(_y, -85, 85);

        transform.localRotation = quaternion.Euler(0, _x , 0);
        _back._cam.transform.localRotation = quaternion.Euler(_y, 0, 0);
    }
}
