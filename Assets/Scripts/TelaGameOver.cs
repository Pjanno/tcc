using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TelaGameOver : MonoBehaviour {

	public static bool GameOver = false;

	public GameObject gameOverUI;

    public void AtivaObjeto()
    {
        Debug.Log("Ativei o objeto");
        gameOverUI.SetActive(true);
    }

	public void FimDeJogo ()
	{
		GameOver = true;
	}
    	
	public void CarregarMenu ()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("SampleScene");
	}

	public void JogarNovamente ()
	{
        Score.scoreValue = 0;
		gameOverUI.SetActive(false);
		Time.timeScale = 1f;
		GameOver = false;
        PlayerPrefs.SetInt("quantidadeTemp", 0);
        SceneManager.LoadScene("Level01");
    }	
}
