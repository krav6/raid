using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager
{
    private PlayerAttributeManager playerAttributeManager;
    private InventoryManager inventoryManager;
    private GraphicRaycaster graphicRaycaster;
    private static SceneManager instance;
    public static SceneManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new SceneManager();
            }

            return instance;
        }
    }

    public static InventoryManager InventoryManager
    {
        get
        {
            if(Instance.inventoryManager == null)
            {
                Instance.inventoryManager = Object.FindObjectOfType<InventoryManager>();
            }

            return Instance.inventoryManager;
        }
    }

    public static PlayerAttributeManager PlayerAttributeManager
    {
        get
        {
            if (Instance.playerAttributeManager == null)
            {
                Instance.playerAttributeManager = Object.FindObjectOfType<PlayerAttributeManager>();
            }

            return Instance.playerAttributeManager;
        }
    }

    public static GraphicRaycaster GraphicRaycaster
    {
        get
        {
            if (Instance.graphicRaycaster == null)
            {
                Instance.graphicRaycaster = Object.FindObjectOfType<GraphicRaycaster>();
            }

            return Instance.graphicRaycaster;
        }
    }
}