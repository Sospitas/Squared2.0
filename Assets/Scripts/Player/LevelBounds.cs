using UnityEngine;
using System.Collections;

public class LevelBounds : MonoBehaviour
{
	private PlayerCloneManager playerCloneManager;
	
	private Transform playerTransform;
	private Transform triggerTransform;
	
	private BoxCollider2D playerColl;
	
	private Vector3 playerPosLeft, playerPosRight, playerPosBot, playerPosTop;
	private Vector3 triggerPosLeft, triggerPosRight, triggerPosBot, triggerPosTop;
	
	void Awake()
	{
		playerTransform = GameObject.Find("Player").transform;
		playerCloneManager = playerTransform.GetComponent<PlayerCloneManager>();
		triggerTransform = this.transform;
		
		playerColl = playerTransform.GetComponent<BoxCollider2D>();
		BoxCollider2D triggerColl = GetComponent<BoxCollider2D>();
		
		triggerPosLeft = new Vector3(triggerTransform.position.x - triggerColl.size.x/2, triggerTransform.position.y, triggerTransform.position.z);
		triggerPosRight = new Vector3(triggerTransform.position.x + triggerColl.size.x/2, triggerTransform.position.y, triggerTransform.position.z);
		triggerPosBot = new Vector3(triggerTransform.position.x, triggerTransform.position.y - triggerColl.size.y/2, triggerTransform.position.z);
		triggerPosTop = new Vector3(triggerTransform.position.x, triggerTransform.position.y + triggerColl.size.y/2, triggerTransform.position.z);
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
// 			Debug.Log("Left Trigger");
			CheckExitSide();
		}
	}
	
	void CheckExitSide()
	{		
		playerPosLeft = new Vector3(playerTransform.position.x - playerColl.size.x/2, playerTransform.position.y, playerTransform.position.z);
		playerPosRight = new Vector3(playerTransform.position.x + playerColl.size.x/2, playerTransform.position.y, playerTransform.position.z);
		playerPosBot = new Vector3(playerTransform.position.x, playerTransform.position.y - playerColl.size.y/2, playerTransform.position.z);
		playerPosTop = new Vector3(playerTransform.position.x, playerTransform.position.y + playerColl.size.y/2, playerTransform.position.z);
		
// 		Debug.Log("PlayerPosLeft: " + playerPosLeft);
// 		Debug.Log("TriggerPosRight: " + triggerPosRight);
// 		Debug.Log("PlayerPosRight: " + playerPosRight);
// 		Debug.Log("TriggerPosLeft: " + triggerPosLeft);
		
		if(playerPosLeft.x > triggerPosRight.x)
		{
// 			Debug.Log("Off Right");
			playerTransform.position = playerCloneManager.GetClonePosition(3);
		}
		else if(playerPosRight.x < triggerPosLeft.x)
		{
// 			Debug.Log("Off Left");
			playerTransform.position = playerCloneManager.GetClonePosition(4);
		}
		
		if(playerPosBot.y > triggerPosTop.y)
		{
// 			Debug.Log("Off Top");
			playerTransform.position = playerCloneManager.GetClonePosition(6);
		}
		else if(playerPosTop.y < triggerPosBot.y)
		{
// 			Debug.Log("Off Bottom");
			playerTransform.position = playerCloneManager.GetClonePosition(1);
		}
	}
}
