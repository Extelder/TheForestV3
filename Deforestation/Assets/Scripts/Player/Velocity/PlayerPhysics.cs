using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerPhysics : MonoBehaviour
{
    [SerializeField] private PlayerGrounded _grounded;

    private CharacterController _characterController;

    public Vector3 Velocity;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        _characterController.Move(Velocity);
    }

    public bool IsGrounded() => _characterController.isGrounded;
}