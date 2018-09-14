using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {
    public string itemName;
    public Sprite sprite;
    public Item item;
    public Item Item
    {
        get
        {
            return item;
        }

        set
        {
            item = value;
        }
    }


    // Use this for initialization
    void Start () {
        item = new Item(itemName, sprite);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
