using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfWalkScript : MonoBehaviour
{
    public float spd;
    [SerializeField] public bool canWalk = true, startedRoutine = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canWalk)
        {
            if (!startedRoutine)
                StartCoroutine(WaitForWolfReturn());
        }

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

    private IEnumerator WaitForWolfReturn()
    {
        startedRoutine = true;
        yield return new WaitForSeconds(5);
        canWalk = true;
        transform.position = new(transform.position.x, transform.position.y, 0);
        startedRoutine = false;
    }
}
