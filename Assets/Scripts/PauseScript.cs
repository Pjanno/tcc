using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

	public static bool JogoPausado = false;
	public GameObject pauseMenuUI, Spawner;

	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			if (JogoPausado) {
				Continuar();
			} else
			{
				Pause();
			}
		}
	}

	public void Continuar ()
	{
        Spawner.GetComponent<FruitSpawner>().LigaSpawner();
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		JogoPausado = false;
	}

	void Pause ()
	{
        Spawner.GetComponent<FruitSpawner>().DesligaSpawner();
        pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		JogoPausado = true;
	}

	public void CarregarMenu ()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("SampleScene");
	}

	public void Sair ()
	{
		Debug.Log ("Saindo do jogo...");
		Application.Quit();
	}
}
