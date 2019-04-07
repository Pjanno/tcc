using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaGameOver : MonoBehaviour {

	public static bool GameOver = false;

	public GameObject gameOverUI;

	public int timeLeft = 60;	

	void Start () {
		StartCoroutine("LoseTime");
	}
	void Update () 
	{
		if (timeLeft <= 0) {
			StopCoroutine("LoseTime");
			FimDeJogo();
		} else {
			Jogando();
		}
	}
	public void FimDeJogo ()
	{
		gameOverUI.SetActive(true);
		Time.timeScale = 0f;
		GameOver = true;
	}

	public void Jogando ()
	{
		gameOverUI.SetActive(false);
		Time.timeScale = 1f;
		GameOver = false;
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
	IEnumerator LoseTime() {
		while (true) {
			yield return new WaitForSeconds(1);
			timeLeft --;
		}
	}

	/*public void Sair ()
	{
		Debug.Log ("Saindo do jogo...");
		Application.Quit();
	}*/
}
