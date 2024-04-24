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

	// Update is called once per frame
	void Update()
	{

	}

	public void LoadLevel(int levelBuildIndexID)
	{
		SceneManager.LoadScene(levelBuildIndexID);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
