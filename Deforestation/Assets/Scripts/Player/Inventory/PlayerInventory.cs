using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class PlayerInventory : SlotsContainer
{
    private PlayerControls _controls;

    public static SelectedSlot SelectedSlot { get; set; }
    
    private void OnEnable()
    {
        _controls = new PlayerControls();
        _controls.Enable();
        _controls.Main.InventoryOpenClose.performed += context => TryInventoryOpenClose();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void TryInventoryOpenClose()
    {
        if (Opened)
            Close();
        else
            Open();
    }
}