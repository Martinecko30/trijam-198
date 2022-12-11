using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplaceWarmth : MonoBehaviour
{
    public GameManager manager;
    public Texture2D warmhands;
    public Texture2D emptyhands;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new(manager.GetComponent<GameManager>().Warmth*.003f, manager.GetComponent<GameManager>().Warmth*.003f, 0f);
    }
    private void OnMouseOver()
    {

        var managerscript = manager.GetComponent<GameManager>();
        managerscript.ChangeCursor(warmhands);
        managerscript.Warmth += 6.5f * (Time.deltaTime * managerscript.loseSpeed);
    }
    private void OnMouseExit()
    {
        var managerscript = manager.GetComponent<GameManager>();
        managerscript.ChangeCursor(emptyhands);
    }
}
