using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private PlayerPhysics _physics;

    private PlayerControls _controls;

    private void Awake()
    {
        _controls = new PlayerControls();
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = transform.TransformDirection(new Vector3(
            _controls.Main.MoveLeftRight.ReadValue<float>() * _moveSpeed * Time.deltaTime,
            0,
            _controls.Main.MoveForwardBackward.ReadValue<float>() * _moveSpeed * Time.deltaTime));

        _physics.Velocity.x = moveDirection.x;
        _physics.Velocity.z = moveDirection.z;
    }
}