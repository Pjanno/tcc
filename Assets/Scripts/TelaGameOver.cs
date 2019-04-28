using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaGameOver : MonoBehaviour {

	public static bool GameOver = false;

	public GameObject gameOverUI;

	void Start () {

	}
	void Update () 
	{

	}

	public void FimDeJogo ()
	{
		gameOverUI.SetActive(true);
		Time.timeScale = 0f;
		GameOver = true;
	}
    	
	public void CarregarMenu ()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("SampleScene");
	}

	public void JogarNovamente ()
	{
		SceneManager.LoadScene("Level01");
		gameOverUI.SetActive(false);
		Time.timeScale = 1f;
		GameOver = false;
	}
	
}
