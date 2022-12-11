using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAttackScript : MonoBehaviour
{
    GameManager manager;
    public GameObject stone;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.Instance;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && manager.Stone)
        {
            var mouspos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            Instantiate(stone, mouspos, Quaternion.identity);
        }
    }
}
