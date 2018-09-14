using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISlotImageManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private bool isDragging = false;
    private int index;
    public class IntToIntEvent : UnityEvent<int, int> { }
    public IntToIntEvent movedToSlot = new IntToIntEvent();
    private GraphicRaycaster rayCaster;

    public int Index
    {
        get
        {
            return index;
        }

        set
        {
            index = value;
        }
    }

    public GraphicRaycaster RayCaster
    {
        get
        {
            return rayCaster;
        }

        set
        {
            rayCaster = value;
        }
    }

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

        List<RaycastResult> results = new List<RaycastResult>();
        RayCaster.Raycast(eventData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.CompareTag("Slot"))
            {
                movedToSlot.Invoke(index, result.gameObject.GetComponent<UISlotManager>().Index);
                return;
            }
        }

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
