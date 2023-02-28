using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickup : RaycastBehaviour
{
    private PickupItem _currentPickupItem;

    private PlayerControls _controls;

    private void OnEnable()
    {
        _controls = new PlayerControls();
        _controls.Enable();
        _controls.Main.Pickup.performed += _controls => TryPickup();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void FixedUpdate()
    {
        if (GetHitCollider(out Collider collider))
        {
            if (collider.TryGetComponent<PickupItem>(out PickupItem pickupItem))
            {
                _currentPickupItem = pickupItem;
                return;
            }
        }

        _currentPickupItem = null;
    }

    private void TryPickup()
    {
        _currentPickupItem?.Pickup();
    }
}