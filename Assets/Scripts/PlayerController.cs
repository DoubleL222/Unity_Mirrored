using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	public KeyCode upControll;
	public KeyCode downControll;
	private float upDownSpeed = 10f;
	private float forwardSpeed = 1f;
	private float stunDuration = 0.4f;
	private float pushBackForce = 25f;
	private Rigidbody myRbd;
	private bool stunned = false;
	private float stunEndTime = float.MinValue;

	// Use this for initialization
	void Start () {
		myRbd = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame

	void Update()
	{
		if (stunned) {
			if (Time.time > stunEndTime) 
			{
				stunned = false;
			}
		}
		
		Vector3 movementVector = Vector3.zero;
		if (Input.GetKey (upControll)) 
		{
			movementVector += Vector3.forward;
		}
		if(Input.GetKey (downControll))
		{
			movementVector += Vector3.back;
		}
		movementVector.Normalize ();
		movementVector *= upDownSpeed;
		if (stunned) 
		{
			myRbd.velocity = new Vector3 (myRbd.velocity.x, 0, movementVector.z);
		} 
		else 
		{
			myRbd.velocity = new Vector3 (forwardSpeed, 0, movementVector.z);
		}

	}

	public void PushBack()
	{
		if (!stunned) {
			myRbd.AddForce (Vector3.left * Random.Range(pushBackForce*0.8f, pushBackForce), ForceMode.VelocityChange);
			stunned = true;
			stunEndTime = Time.time + stunDuration;
		}
	}
}
