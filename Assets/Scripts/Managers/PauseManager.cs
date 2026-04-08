using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

	public static bool gamePaused;

	public GameObject pauseMenuUI;
	public GameObject hudCanvas;



	void Start()
	{

	}

	void Update()
	{
        // If the escape button is pressed...
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (gamePaused)
			{
				Unpause();
			}
			else
            {
				Pause();
            }

		}
	}

	public void Pause()
	{
		pauseMenuUI.SetActive(true);
		hudCanvas.SetActive(false);
		Time.timeScale = 0f;
		gamePaused = true;
		Cursor.visible = true;

	}

	public void Unpause()
	{
        pauseMenuUI.SetActive(false);
		hudCanvas.SetActive(true);
		Time.timeScale = 1f;
		gamePaused = false;
	}

    public void Restart()
    {
		SceneManager.LoadScene("CutScene1");
    }

    public void LoadMenu()
    {
		SceneManager.LoadScene("MainMenu");
    }
}