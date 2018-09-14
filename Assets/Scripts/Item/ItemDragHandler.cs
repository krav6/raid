using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private bool isDragging = false;
    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        transform.localPosition = Vector3.zero;
    }

    void Update()
    {
        if(isDragging)
        {
            transform.position = Input.mousePosition;
        }
    }
}
