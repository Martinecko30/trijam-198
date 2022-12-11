using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplaceWarmth : MonoBehaviour
{
    private GameManager manager;

    private float fireIntensity = 100;
    private float loseSpeed = 1.2f;

    void Start()
    {
        manager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        fireIntensity -= 2.5f * (Time.deltaTime * loseSpeed);
        fireIntensity = Mathf.Clamp(fireIntensity, 0, 100);
        transform.localScale = new(fireIntensity * .003f, fireIntensity * .003f, 0f);
    }

    private void OnMouseDown()
    {
        if(manager.Wood)
        {
            fireIntensity += 15;
            manager.Wood = false;
            manager.ChangeCursor(manager.fireCursor);
        }
    }

    private void OnMouseEnter()
    {
        if(!manager.Wood && !manager.Stone)
            manager.ChangeCursor(manager.fireCursor);
    }

    private void OnMouseOver()
    {
        manager.Warmth += 6.5f * (Time.deltaTime * manager.loseSpeed);
    }
    private void OnMouseExit()
    {
        if (!manager.Wood && !manager.Stone)
            manager.ChangeCursor(manager.defaultCursor);
    }
}
