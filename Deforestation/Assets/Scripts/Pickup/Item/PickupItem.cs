using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PickupItem : MonoBehaviour, IPickuptable
{
    public Item CurrentItem;
    [field: SerializeField] public int Amount { get; set; }

    private PlayerInventory _playerInventory;

    [Inject]
    private void Init(PlayerInventory playerInventory)
    {
        _playerInventory = playerInventory;
    }

    public void Pickup()
    {
        _playerInventory.AddItem(this);
    }
}