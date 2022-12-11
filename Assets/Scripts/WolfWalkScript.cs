using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfWalkScript : MonoBehaviour
{
    public float spd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var anim = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        if (anim.IsTag("walk"))
            transform.position = new(transform.position.x + spd * Time.deltaTime, -1.67f, 0);


        if (anim.IsTag("hurt") && anim.normalizedTime >= 1)
        {
            GetComponent<Animator>().Play("NewWolfAnim");
        }

        if (transform.position.x >= 14 || transform.position.x <= -14)
        {
            spd *= -1;
            transform.localScale = new(-transform.localScale.x, .25f, 0);
        }
    }
}
