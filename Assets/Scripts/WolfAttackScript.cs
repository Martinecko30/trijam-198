using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAttackScript : MonoBehaviour
{
    GameManager manager;
    public GameObject stone;
    void Start()
    {
        manager = GameManager.Instance;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && manager.Stone)
        {
            var mouspos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            Instantiate(stone, mouspos, Quaternion.identity);

            manager.Stone = false;
            manager.ChangeCursor(manager.defaultCursor);

            GetComponent<WolfWalkScript>().canWalk = false;
        }
    }
}
