using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPickup : MonoBehaviour
{
    GameManager manager;
    private void Start()
    {
        manager = GameManager.Instance;
    }

    private void OnMouseDown()
    {
        if (!manager.Wood)
        {
            manager.Wood = true;
            manager.ChangeCursor(manager.woodCursor);
        }
        else
        {
            manager.Wood = false;
            manager.ChangeCursor(manager.defaultCursor);
        }
    }
}
