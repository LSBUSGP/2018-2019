using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform focusPoint;
    public float speed;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (focusPoint.gameObject.activeSelf)
        {
            transform.position = Vector3.Lerp(transform.position, focusPoint.position, speed * Time.deltaTime);
        }
    }
}