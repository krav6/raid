using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public string Name 
    {
        get { return name; }
        set { name = value; }
    }

    public Sprite image;
    public Sprite Image
    {
        get { return image; }
        set { image = value; }
    }
    public Item(string name)
    {
        Name = name;
    }


}
