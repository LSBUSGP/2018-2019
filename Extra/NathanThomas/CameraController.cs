using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 cameraPosition = Vector3.zero;
    public Vector3 offset;
    public Transform target;


    // Use this for initialization
    void FixedUpdate()
    {
        cameraPosition = new Vector3(Mathf.SmoothStep(transform.position.x, target.transform.position.x, 0.3f),
                                     Mathf.SmoothStep(transform.position.y, target.transform.position.y, 0.3f));
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        transform.position = cameraPosition + Vector3.forward * -10 + offset;
    }
}