using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float maxSpeed = 3f;
	public float speedModifier = 50f;
	public float jumpSpeed = 200f;
	public float maxYVel = 20f;
	public bool  isGrounded = false;
	
	public bool  flipGravity = false;
	
	private Rigidbody2D rigidBody;
	
	private float velocityModifier = 0.0f;


	
	// Use this for initialization
	void Awake ()
	{
		// Set collision for ground checks and player to be ignored
		Physics2D.IgnoreLayerCollision(8, 9, true);
		// Set collision for ground checks and level trigger to be ignored
		Physics2D.IgnoreLayerCollision(9, 10, true);
		
		rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		CheckInputs();
	}
	
	void FixedUpdate()
	{		
		if(flipGravity && isGrounded)
		{
			flipGravity = false;
			Physics2D.gravity *= -1;
		}
	
		if (rigidBody.velocity.y > maxYVel && rigidBody.velocity.y > 0) 
			rigidBody.velocity = new Vector2 (speedModifier * velocityModifier, maxYVel);	
		else if(rigidBody.velocity.y < -maxYVel && rigidBody.velocity.y < 0) 
			rigidBody.velocity = new Vector2 (speedModifier * velocityModifier, -maxYVel);
		else 
			rigidBody.velocity = new Vector2 (speedModifier * velocityModifier, rigidBody.velocity.y);
		
		if(rigidBody.velocity.x > maxSpeed)
			rigidBody.velocity = new Vector2(maxSpeed, rigidBody.velocity.y);
		else if(rigidBody.velocity.x < -maxSpeed)
			rigidBody.velocity = new Vector2(-maxSpeed, rigidBody.velocity.y);
	}
	
	void CheckInputs()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(isGrounded)
				flipGravity = true;
		}
		
		if(Input.GetKey(KeyCode.D))
		{
			velocityModifier = 1.0f;
		}
		else if(Input.GetKey(KeyCode.A))
		{
			velocityModifier = -1.0f;
		}
		else if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
		{
			velocityModifier = 0.0f;
		}
	}
	
	public void SetGrounded(bool newValue)
	{
		isGrounded = newValue;
	}
}
