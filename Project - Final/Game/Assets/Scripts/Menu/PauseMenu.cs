using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool isPaused = false;

	public GameObject pauseMenuUI;


	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			if (isPaused)
			{
				Resume();
			}

			else
			{
				Pause();
			}
		}
	}

	public void Resume()
	{
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		isPaused = false;
	}

	void Pause()
	{
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		isPaused = true;
	}

	public void MainMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(0);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}