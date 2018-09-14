using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIInventoryManager : MonoBehaviour {
    public InventoryManager inventoryReference;
    public GameObject inventorySlotPrefab;
    public GameObject inventorySlotImagePrefab;
    private Dictionary<int, GameObject> itemSlots;
    private Dictionary<int, GameObject> itemSlotImages;
    private UnityAction<int> itemAddedAction;

    void Start () {
        GetComponent<RectTransform>().sizeDelta = new Vector2(inventoryReference.numberOfSlots * 70, 60);
        itemSlots = new Dictionary<int, GameObject>();
        itemAddedAction += addSlotImage;
        inventoryReference.itemAdded.AddListener(itemAddedAction);
        for (int i = 0; i < inventoryReference.numberOfSlots; i++)
        {
            addSlot(i);
        }
	}
	
    void addSlot(int slotIndex)
    {
        GameObject slotObject = Instantiate(inventorySlotPrefab, transform);
        itemSlots.Add(slotIndex, slotObject);
    }

    void addSlotImage(int slotIndex)
    {
        GameObject slotImageObject = Instantiate(inventorySlotImagePrefab, itemSlots[slotIndex].transform);
        slotImageObject.GetComponent<Image>().sprite = inventoryReference.getItemOfSlotIndex(slotIndex).Image;
    }

    void removeSlotImage(int slotIndex)
    {
        itemSlotImages.Remove(slotIndex);
    }

    void updateSlotImage(int slotIndex)
    {
        removeSlotImage(slotIndex);
        addSlotImage(slotIndex);
    }
}
