using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonePickup : MonoBehaviour
{
    GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!manager.Stone)
        {
            manager.Stone = true;
            manager.Wood = false;
            manager.ChangeCursor(manager.stoneCursor);
        }
        else
        {
            manager.Stone = false;
            manager.ChangeCursor(manager.defaultCursor);
        }
    }
}
