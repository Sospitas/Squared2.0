using UnityEngine;
using System.Collections;

public class LevelExit : MonoBehaviour
{
	public Vector3 playerTextOffset = new Vector3(0.0f, 2.0f, 0.0f);
	
	private RectTransform textTransform;
	private Transform playerTransform;
	private bool isPlayerInEndZone = false;
	
	void Awake()
	{	
		textTransform = GameObject.Find("ScreenSpaceCanvas/ExitText").GetComponent<RectTransform>();
		textTransform.gameObject.SetActive(false);
	}
	
	void Update()
	{
		if(isPlayerInEndZone)
		{
			// Render text above player to tell them to exit level
			RenderExitMessageAbovePlayer(playerTransform);
			
			if(Input.GetKeyDown(KeyCode.E))
			{
				Application.LoadLevel("Menu");
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			isPlayerInEndZone = true;			
			playerTransform = other.transform;
			textTransform.gameObject.SetActive(true);
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			isPlayerInEndZone = false;
			playerTransform = null;
			textTransform.gameObject.SetActive(false);
		}
	}
	
	void RenderExitMessageAbovePlayer(Transform trans)
	{
		if(!playerTransform) return;
		
		textTransform.position = playerTransform.position + playerTextOffset;
	}
}