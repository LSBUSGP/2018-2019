using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    Transform player;
    public float rotationSpeed;
    Vector3 targetPos;

    public GameObject origin; //enemy that fired this projectile


    Rigidbody2D RB;

    

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
        targetPos = player.position;
        Destroy(gameObject, 4);       
    }

    void Update()
    {
        RB.velocity = transform.right * speed * Time.deltaTime;
        transform.Rotate(Vector3.right * rotationSpeed);
    }

    
}
