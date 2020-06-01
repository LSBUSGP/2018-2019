using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float playerSpeed = 10f;

	private Rigidbody2D playerBody;
	private Vector2 movement;

	void Start () 
	{
		playerBody = GetComponent<Rigidbody2D>();
	}
	
	void Update () 
	{
		if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
		{
			movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
			transform.right = movement;
		}
		else
		{
			movement = new Vector2(0, 0);
		}

		playerBody.velocity = movement * playerSpeed;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Bullet"))
		{
			Destroy(other.gameObject);
			StartCoroutine(HitIndicator());
		}
	}

	private IEnumerator HitIndicator()
	{
		GetComponent<SpriteRenderer>().color = Color.red;
		yield return new WaitForSeconds(0.2f);
		GetComponent<SpriteRenderer>().color = Color.white;
	}
}