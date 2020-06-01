using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

	private TurretFire turretScript;
	private float speed;
	private Rigidbody2D bulletBody;
	private Vector2 direction;

	void Start () 
	{
		turretScript = GameObject.FindGameObjectWithTag("Turret").GetComponent<TurretFire>();
		bulletBody = GetComponent<Rigidbody2D>();
		speed = turretScript.shotSpeed;
		direction = transform.up;
		Destroy(gameObject, 10f);
	}
	
	void Update () 
	{
		bulletBody.velocity = direction * speed;
	}
}