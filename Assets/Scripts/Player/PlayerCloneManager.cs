using UnityEngine;
using System.Collections;

public class PlayerCloneManager : MonoBehaviour
{
	/*	0---1---2
		|   |   |
		3---P---4
		|   |   |
		5---6---7	*/
		
	public GameObject clonePrefab;
	
	
	private Transform playerTransf;
	private Transform cloneParentTransf;
	private GameObject[] playerClones;
	
	private float screenWidth;
	private float screenHeight;
	
	// Use this for initialization
	void Awake ()
	{
		var cam = Camera.main;
		
		playerTransf = this.transform;
		cloneParentTransf = playerTransf.Find("Clones").GetComponent<Transform>();
		
		var screenBottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, playerTransf.position.z));
		var screenTopRight = cam.ViewportToWorldPoint(new Vector3(1, 1, playerTransf.position.z));
		
		screenWidth = screenTopRight.x - screenBottomLeft.x;
		screenHeight = screenTopRight.y - screenBottomLeft.y;
			
		playerClones = new GameObject[8];
		
		playerClones[0] = GameObject.Instantiate(clonePrefab, new Vector2(playerTransf.position.x - screenWidth, playerTransf.position.y + screenHeight), Quaternion.identity) as GameObject;
		playerClones[1] = GameObject.Instantiate(clonePrefab, new Vector2(playerTransf.position.x, playerTransf.position.y + screenHeight), Quaternion.identity) as GameObject;
		playerClones[2] = GameObject.Instantiate(clonePrefab, new Vector2(playerTransf.position.x + screenWidth, playerTransf.position.y + screenHeight), Quaternion.identity) as GameObject;
		playerClones[3] = GameObject.Instantiate(clonePrefab, new Vector2(playerTransf.position.x - screenWidth, playerTransf.position.y), Quaternion.identity) as GameObject;
		playerClones[4] = GameObject.Instantiate(clonePrefab, new Vector2(playerTransf.position.x + screenWidth, playerTransf.position.y), Quaternion.identity) as GameObject;
		playerClones[5] = GameObject.Instantiate(clonePrefab, new Vector2(playerTransf.position.x - screenWidth, playerTransf.position.y - screenHeight), Quaternion.identity) as GameObject;
		playerClones[6] = GameObject.Instantiate(clonePrefab, new Vector2(playerTransf.position.x, playerTransf.position.y - screenHeight), Quaternion.identity) as GameObject;
		playerClones[7] = GameObject.Instantiate(clonePrefab, new Vector2(playerTransf.position.x + screenWidth, playerTransf.position.y - screenHeight), Quaternion.identity) as GameObject;
		
		if(cloneParentTransf)
		{
			for(int i = 0; i < 8; i++)
			{
				playerClones[i].transform.parent = cloneParentTransf;
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		UpdateClonePositions();
	}
	
	void UpdateClonePositions()
	{
		playerClones[0].transform.position = new Vector2(playerTransf.position.x - screenWidth, playerTransf.position.y + screenHeight);
		playerClones[1].transform.position = new Vector2(playerTransf.position.x, playerTransf.position.y + screenHeight);
		playerClones[2].transform.position = new Vector2(playerTransf.position.x + screenWidth, playerTransf.position.y + screenHeight);
		playerClones[3].transform.position = new Vector2(playerTransf.position.x - screenWidth, playerTransf.position.y);
		playerClones[4].transform.position = new Vector2(playerTransf.position.x + screenWidth, playerTransf.position.y);
		playerClones[5].transform.position = new Vector2(playerTransf.position.x - screenWidth, playerTransf.position.y - screenHeight);
		playerClones[6].transform.position = new Vector2(playerTransf.position.x, playerTransf.position.y - screenHeight);
		playerClones[7].transform.position = new Vector2(playerTransf.position.x + screenWidth, playerTransf.position.y - screenHeight);
	}
	
	public Vector2 GetClonePosition(int index)
	{
		if(index < 0 || index > 7)
		{
// 			Debug.Log("Incorrect index. Returning Vector2.Zero");
			return Vector2.zero;
		}
		
		return playerClones[index].transform.position;
	}
}
