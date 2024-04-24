using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


	// Start is called before the first frame update
	void Start()
	{
		// makes the cursor visible and usable for the main menu.
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	// load the level with the given build index.
	public void LoadLevel(int levelBuildIndexID)
	{
		SceneManager.LoadScene(levelBuildIndexID);
	}

	// quit the game.
	public void Quit()
	{
		Application.Quit();
	}
}
