using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIInventoryManager : MonoBehaviour {
    public InventoryManager inventoryReference;
    public GameObject inventorySlotPrefab;
    public GameObject inventorySlotImagePrefab;
    public GraphicRaycaster graphicsRayCasterReference;
    private Dictionary<int, GameObject> itemSlots;
    private Dictionary<int, GameObject> itemSlotImages;
    private UnityAction<int> itemAddedAction;
    private UnityAction<int> itemRemovedAction;
    private UnityAction<int, int> slotImageMovedAction;

    void Start () {
        GetComponent<RectTransform>().sizeDelta = new Vector2(inventoryReference.numberOfSlots * 70, 60);
        itemSlots = new Dictionary<int, GameObject>();
        itemSlotImages = new Dictionary<int, GameObject>();
        itemAddedAction += addSlotImage;
        itemRemovedAction += removeSlotImage;
        slotImageMovedAction += moveSlotImage;
        inventoryReference.itemAdded.AddListener(itemAddedAction);
        inventoryReference.itemRemoved.AddListener(itemRemovedAction);

        for (int i = 0; i < inventoryReference.numberOfSlots; i++)
        {
            addSlot(i);
        }
	}
	
    void addSlot(int slotIndex)
    {
        GameObject slotObject = Instantiate(inventorySlotPrefab, transform);
        slotObject.name = "Slot-" + slotIndex;
        slotObject.GetComponent<UISlotManager>().Index = slotIndex;
        itemSlots.Add(slotIndex, slotObject);
    }

    void addSlotImage(int slotIndex)
    {
        GameObject slotImageObject = Instantiate(inventorySlotImagePrefab, itemSlots[slotIndex].transform);
        slotImageObject.name = "SlotImage-" + slotIndex;
        UISlotImageManager uiSlotImage = slotImageObject.GetComponent<UISlotImageManager>();
        uiSlotImage.Index = slotIndex;
        uiSlotImage.RayCaster = graphicsRayCasterReference;
        uiSlotImage.movedToSlot.AddListener(slotImageMovedAction);
        slotImageObject.GetComponent<Image>().sprite = inventoryReference.getItemOfSlotIndex(slotIndex).Image;
        itemSlotImages.Add(slotIndex, slotImageObject);
    }

    void removeSlotImage(int slotIndex)
    {
        GameObject itemSlotImage = itemSlotImages[slotIndex];
        itemSlotImages.Remove(slotIndex);
        Destroy(itemSlotImage);
    }

    void updateSlotImage(int slotIndex)
    {
        removeSlotImage(slotIndex);
        addSlotImage(slotIndex);
    }

    void moveSlotImage(int fromIndex, int toIndex)
    {
        inventoryReference.moveItemFromSlotToSlot(fromIndex, toIndex);
    }
}
