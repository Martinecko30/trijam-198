using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var shrink = 1f;
        transform.position = new(transform.position.x, transform.position.y, 0);
        transform.localScale = new(transform.localScale.x - shrink * Time.deltaTime, transform.localScale.x, 0);
        transform.rotation = new(0, 0, transform.rotation.z + 1 * Time.deltaTime, 0);
        if (transform.localScale.x <= .2f) { Destroy(gameObject); }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (transform.localScale.x <= .3f && collision.gameObject.tag == "WolfTag")
        {
            Debug.Log(collision.gameObject.tag);
            collision.GetComponent<Animator>().Play("WolfHurtAnim");
            Destroy(gameObject);
        }
    }
}
