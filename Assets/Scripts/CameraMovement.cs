using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float maxOffset, moveSpeed;

    private void Update()
    {
        if (Input.mousePosition.x < Screen.width / 6f)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-maxOffset, 0, -10), Time.deltaTime * moveSpeed);
        } else if (Input.mousePosition.x > Screen.width / 6f * 5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(maxOffset, 0, -10), Time.deltaTime * moveSpeed);
        }
    }
}
