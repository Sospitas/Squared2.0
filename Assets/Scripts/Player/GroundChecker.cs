using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour
{
	public bool isTop = false;
	
	private PlayerController playerController;
	
	void Awake()
	{
		playerController = transform.parent.GetComponent<PlayerController>();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		playerController.SetGrounded(true);
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		playerController.SetGrounded(true);
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("Set Grounded False");
		playerController.SetGrounded(false);
	}
}
