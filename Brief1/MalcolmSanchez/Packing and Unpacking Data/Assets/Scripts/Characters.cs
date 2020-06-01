using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Characters : MonoBehaviour {

	[SerializeField]
	private float speed;
	protected Vector3 direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update ()
	{
		move ();
	}

	public void move()
	{
		transform.Translate (direction*speed*Time.deltaTime);
	}
}
