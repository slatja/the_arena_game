using Invector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Invector
{
	using vCharacterController;
	public class MenuController : MonoBehaviour
	{
		public string mainMenuScene;
		public GameObject pauseMenu;
		public GameObject deathMenu;
		public bool isPaused;
		static public bool playerDead;
		public bool unlockCursor;
		public string NewGameScene;
		
		// Start is called before the first frame update
		void Start()
		{
			
		}

		// Update is called once per frame
		void Update()
		{
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				if(isPaused)
				{
					ResumeGame();
				}else
				{
					isPaused = true;
					pauseMenu.SetActive(true);
					Time.timeScale = 0f;
					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;
				}
			}

			if(playerDead)
			{
				deathMenu.SetActive(true);
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
		}
		
		//resets pause state, removes pause menu and relocks cursor
		public void ResumeGame()
		{
			isPaused = false;
			pauseMenu.SetActive(false);
			Time.timeScale = 1f;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		
		//unpaused game, resets player death status and loads mainmenu scene
		public void ReturnToMain()
		{
			Time.timeScale = 1f;
			SceneManager.LoadScene(mainMenuScene);
			playerDead = false;
		}

		//reloads game scene (kingshalls), removes player death status and removes death menu
		public void NewGame()
		{
			SceneManager.LoadScene(NewGameScene);
			playerDead = false;
			deathMenu.SetActive(false);
		}
	}
}
