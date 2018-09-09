using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIInventoryManager : MonoBehaviour {
    public InventoryManager inventoryReference;
    public GameObject inventoryElementPrefab;
    private Dictionary<int, GameObject> itemSlots;
    private UnityAction<int> itemAddedAction;

    void Start () {
        itemSlots = new Dictionary<int, GameObject>();
        itemAddedAction += updateUI;
        inventoryReference.itemAdded.AddListener(itemAddedAction);
	}
	
    void updateUI(int slotIndex)
    {
        GameObject slotObject = Instantiate(inventoryElementPrefab, transform);
        slotObject.GetComponentInChildren<Text>().text = inventoryReference.getItemOfSlotIndex(slotIndex).Name;
        itemSlots.Add(slotIndex, slotObject);
    }
}
