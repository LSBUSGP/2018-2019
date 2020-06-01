using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform exitPoint;
    public bool leftEject;
    Vector2 topLeft = new Vector2(-1, 1);
    Vector2 topRight = new Vector2(1, 1);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            rb.velocity = Vector3.zero;
            other.transform.position = exitPoint.position;
            float verticalForce = rb.GetComponent<PlayerController>().verticalForce;
            if (leftEject)
            {
                rb.AddForce(topLeft * 75f * verticalForce);
            }
            else
            {
                rb.AddForce(topRight * 75f * verticalForce);
            }
        }
    }
}