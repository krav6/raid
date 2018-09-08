using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour {
    private InventoryManager inventory;

    void Start()
    {
        inventory = GetComponent<InventoryManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickable"))
        {
            if(inventory.addItem(other.GetComponent<Item>()))
            {
                Destroy(other.gameObject);
            }
        } 
    }
}
