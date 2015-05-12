using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	public void PressPlayButton()
	{
		Application.LoadLevel("Level");
	}
		// TODO: Load level scene with current level
	
	public void PressLevelSelectButton()
	{
		// TODO: Load level selection scene
	}
	
	public void PressQuitButton()
	{
		Application.Quit();
	}
}
