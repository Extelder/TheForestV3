using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private PlayerCursor _playerCursor;
    [SerializeField] private Item _defaultItem;

    private Canvas _canvas;
    private bool _opened;

    [field: SerializeField] public InventorySlot[] InventorySlots { get; private set; }

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
        _opened = _canvas.enabled;

        for (int i = 0; i < InventorySlots.Length; i++)
        {
            InventorySlots[i].NumberInOrder = i;
            InventorySlots[i].CurrentItem = _defaultItem;
        }

        Open();
    }

    public void Open()
    {
        _opened = true;
        _canvas.enabled = true;
        _playerCursor.Enable();
    }

    public void Close()
    {
        _opened = false;
        _canvas.enabled = false;
        _playerCursor.Disable();
    }

    public void AddItem(PickupItem item)
    {
        foreach (InventorySlot inventorySlot in InventorySlots)
        {
            if (inventorySlot.CurrentItem == item.CurrentItem)
            {
                if ((inventorySlot.Amount + item.Amount) > inventorySlot.CurrentItem.MaxAmount)
                {
                    int delta = inventorySlot.CurrentItem.MaxAmount - inventorySlot.Amount;
                    inventorySlot.Amount += delta;
                    item.Amount -= delta;
                    inventorySlot.DataChanged();
                    Debug.Log("Items summ bigger than maxamount");
                    Debug.Log(delta);
                }

                if ((inventorySlot.Amount + item.Amount) <= inventorySlot.CurrentItem.MaxAmount)
                {
                    inventorySlot.Amount += item.Amount;
                    inventorySlot.DataChanged();
                    Debug.Log("Item summ lesser than maxamiunt");
                    return;
                }
            }
        }

        foreach (InventorySlot inventorySlot in InventorySlots)
        {
            if (inventorySlot.CurrentItem == _defaultItem)
            {
                inventorySlot.ChangeCurrentItem(item);
                return;
            }
        }
    }
}