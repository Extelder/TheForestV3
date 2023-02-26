using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _gravity = 3f;
    [SerializeField] private PlayerPhysics _physics;

    private PlayerControls _controls;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Awake()
    {
        _controls = new PlayerControls();
    }

    private void OnEnable()
    {
        _controls.Enable();

        _controls.Main.Jump.performed += context => Jump();
    }

    private void OnDisable()
    {
        _disposable.Clear();

        _controls.Disable();
    }

    private void FixedUpdate()
    {
        if (!_physics.IsGrounded())
        {
            _physics.Velocity.y += _gravity * Time.deltaTime;
        }
    }

    private void Jump()
    {
        if (!_physics.IsGrounded())
            return;

        _physics.Velocity.y = 0;
        _physics.Velocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravity);
    }
}