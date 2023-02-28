using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDropInventorySlot : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        GetComponent<RectTransform>().position += new Vector3(eventData.delta.x, eventData.delta.y);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Делаем картинку прозрачнее
        GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.75f);
        // Делаем так чтобы нажатия мышкой не игнорировали эту картинку
        GetComponentInChildren<Image>().raycastTarget = false;
        // Делаем наш DraggableObject ребенком InventoryPanel чтобы DraggableObject был над другими слотами инвенторя
        transform.SetParent(transform.parent.parent);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Делаем картинку опять не прозрачной
        GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1f);
        // И чтобы мышка опять могла ее засечь
        GetComponentInChildren<Image>().raycastTarget = true;
        if (eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<InventorySlot>() != null)
        {
            Debug.Log("Detect " + eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
        }
    }
}