using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public int NumberInOrder { get; set; }
    public Item CurrentItem { get; set; }
    public int Amount { get; set; }

    public event Action ItemValuesChanged;


    public void DataChanged()
    {
        ItemValuesChanged?.Invoke();
    }

    public void ChangeCurrentItem(PickupItem item)
    {
        CurrentItem = item.CurrentItem;
        Amount = item.Amount;

        DataChanged();
    }
}