using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAlice : MonoBehaviour {
	public Transform target;
	public Transform myTransform;
	public float chaseRange;

	// Use this for initialization
	void Update()
			{
		float DistanceToTarget = Vector3.Distance (transform.position, target.position);
			if (DistanceToTarget < chaseRange){
				
			transform.LookAt (target); 
		transform.Translate (Vector3.forward * 15* Time.deltaTime);
			}
			}
}