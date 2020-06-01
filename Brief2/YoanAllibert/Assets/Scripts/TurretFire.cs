using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFire : MonoBehaviour {

	public Rigidbody2D player;
	public GameObject bullet;
	public float shotSpeed = 10f;

	private void Update()
	{
		CalculateImpact(); //Every frame, the turret will point towards potential impact point if it were to fire
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			FireBullet(); //We fire using the turret's localRotation
		}
	}

	void CalculateImpact()
	{	
		//See separate document for explaination on how we found the float a, b and c. 
		float a = (player.velocity.x * player.velocity.x) + (player.velocity.y * player.velocity.y) - (shotSpeed * shotSpeed);

		float b = 2 * (player.velocity.x * (player.gameObject.transform.position.x - transform.position.x)
					+ player.velocity.y * (player.gameObject.transform.position.y - transform.position.y));

		float c = ((player.gameObject.transform.position.x - transform.position.x) * (player.gameObject.transform.position.x - transform.position.x))
					+ ((player.gameObject.transform.position.y - transform.position.y) * (player.gameObject.transform.position.y - transform.position.y));



		
	
		float disc = b * b - (4 * a * c); //We check if there are solutions by calculating the discriminant

		if (disc < 0) //If the bullet speed is lower than the player speed, there might not be any solution.
		{
			Debug.Log("No possible hit!");
		}
		else
		{
			float t1 = (-1 * b + Mathf.Sqrt(disc)) / (2 * a); //We solve the equation using the + and - to check for the two solutions of impact
			float t2 = (-1 * b - Mathf.Sqrt(disc)) / (2 * a);
			float t = Mathf.Max(t1, t2); // We take the larger time value, the turret will aim for the second point of impact

			float aimX = player.gameObject.transform.position.x + (player.velocity.x * t); //apply the time to the velocity to get the position of impact
			float aimY = player.gameObject.transform.position.y + (player.velocity.y * t);
			Vector2 impactPos = new Vector2 (aimX,aimY); //Point of impact is now calculated, time to rotate the turret

			RotateTurret(impactPos); //now rotate the turret
		}
	}

	public void RotateTurret(Vector2 impactPos)
	{ 
		float turretAngle  = Mathf.Atan2(impactPos.y - transform.position.y, impactPos.x - transform.position.x) * Mathf.Rad2Deg; //turret angle is converted to degree
		turretAngle -= 90; //art correction
		transform.localRotation = Quaternion.Euler(0, 0, turretAngle); //We rotate to the correct angle
	}

	void FireBullet()
	{	
		Instantiate (bullet, transform.position, transform.localRotation); //instantiate bullet to the rotation of the turret
	}
}