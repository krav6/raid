using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    private string name;
    public string Name 
    {
        get { return name; }
        set { name = value; }
    }

    private Sprite image;
    public Sprite Image
    {
        get { return image; }
        set { image = value; }
    }
    public Item(string name, Sprite image)
    {
        Name = name;
        Image = image;
    }

    public Item(Item item)
    {
        Name = item.Name;
        Image = item.Image;
    }
}
