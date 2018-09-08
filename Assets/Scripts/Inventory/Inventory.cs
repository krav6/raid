using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public int numberOfSlots;
    private Dictionary<int, Item> inventory = new Dictionary<int, Item>();

    public bool addItem(Item item)
    {
        int emptySlotIndex = findEmptySlot();
        if(emptySlotIndex == -1)
        {
            return false;
        }

        inventory.Add(emptySlotIndex, item);

        return true;
    }

    public bool addItemToSlot(int slotIndex, Item item)
    {
        if (!isSlotEmpty(slotIndex))
        {
            return false;
        }

        inventory.Add(slotIndex, item);

        return true;
    }

    public void removeItemFromSlot(int slotIndex)
    {
        inventory.Remove(slotIndex);
    }

    public bool moveItemFromSlotToSlot(int fromSlotIndex, int toSlotIndex)
    {
        if(isSlotIndexOutOfBoundaries(fromSlotIndex) || isSlotIndexOutOfBoundaries(toSlotIndex))
        {
            return false;
        }

        Item fromItem = getItemOfSlotIndex(fromSlotIndex);
        Item toItem = getItemOfSlotIndex(toSlotIndex);

        if(fromItem == null)
        {
            return false;
        }

        removeItemFromSlot(fromSlotIndex);
        if (toItem == null)
        {
            return addItemToSlot(toSlotIndex, fromItem);
        }

        removeItemFromSlot(toSlotIndex);
        addItemToSlot(fromSlotIndex, toItem);
        return addItemToSlot(toSlotIndex, fromItem);
    }

    private Item getItemOfSlotIndex(int slotIndex)
    {
        Item item = null;
        if (inventory.TryGetValue(slotIndex, out item))
        {
            return item;
        }

        return item;
    }

    private bool isSlotIndexOutOfBoundaries(int slotIndex)
    {
        return slotIndex < 0 || slotIndex >= numberOfSlots;
    }

    private bool isSlotEmpty(int slotIndex)
    {
        return !inventory.ContainsKey(slotIndex);
    }

    private int findEmptySlot()
    {
        for (int i = 0; i < numberOfSlots; ++i)
        {
            if (isSlotEmpty(i))
            {
                return i;
            }
        }

        return -1;
    }
}
