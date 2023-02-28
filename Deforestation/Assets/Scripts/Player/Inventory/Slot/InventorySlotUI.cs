using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private InventorySlot _slot;

    [SerializeField] private TextMeshProUGUI _amountText;
    [SerializeField] private Image _image;

    private void OnEnable()
    {
        _slot.ItemValuesChanged += OnItemValuesChanged;
    }

    private void OnDisable()
    {
        _slot.ItemValuesChanged -= OnItemValuesChanged;
    }

    private void OnItemValuesChanged()
    {
        _amountText.text = _slot.Amount.ToString();
        _image.sprite = _slot.CurrentItem.Icon;
    }
}