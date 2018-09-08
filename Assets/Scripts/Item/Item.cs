using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public string Name 
    {
        get { return name; }
        set { name = value; }
    }

    public Item(string name)
    {
        Name = name;
    }
}
