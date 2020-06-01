using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform enemy;

    public float speed;
    public Vector3 posRight = new Vector3(2, 0, 0);
    public Vector3 posLeft = new Vector3(-2, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(posLeft, posRight, Mathf.PingPong(Time.time * speed, 1.0f)); 
    }
	
}
