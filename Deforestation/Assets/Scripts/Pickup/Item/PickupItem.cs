using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PickupItem : MonoBehaviour, IPickuptable
{
    public Item CurrentItem;
    [field: SerializeField] public int Amount { get; set; }


    public void Pickup()
    {
        PlayerInventory.Instance.AddItem(this);
    }
}