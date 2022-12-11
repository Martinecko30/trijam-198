using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfKilling : MonoBehaviour
{
    [SerializeField] private float defaultChance;
    [SerializeField] private float chanceToKill = 0.001f;
    [SerializeField] private float chanceMultiplier = 0.00002f;

    [SerializeField] private WolfWalkScript walking;

    public GameObject killingImage;

    private void Start()
    {
        killingImage.SetActive(false);
        defaultChance = chanceToKill;
        walking = GetComponent<WolfWalkScript>();
    }

    private void Update()
    {
        if (GameManager.Instance.dead)
            return;
        if (!walking.canWalk)
            chanceToKill = defaultChance;
        if (walking.canWalk)
        {
            chanceToKill += chanceMultiplier * Time.deltaTime;
        }

        var value = Random.value;
        Debug.Log(value);
        if (value < chanceToKill)
        {
            Attack();
        }
    }

    private void Attack()
    {
        killingImage.SetActive(true);
        GameManager.Instance.Death();
    }
}
