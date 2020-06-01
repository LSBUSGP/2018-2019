using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp: MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUpGrow")
            {
            transform.localScale += new Vector3(3, 3, 3);

        }


        {
            Destroy(other.gameObject);
        }
    }
}