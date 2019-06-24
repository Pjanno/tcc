using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static int scoreValue = 0;
	Text scoreText;
    bool JaToquei = false;

    GameObject am;
    public GameObject player;

    public GameObject fimDeJogoNormal;
    public GameObject fruitSpawner;

    void Start () {
		scoreText = GetComponent<Text>();
        am = GameObject.Find("AudioManager");
    }
	void Update () {
		scoreText.text = "" + scoreValue;
        GameOverAtivado();
		//a contagem está no script destroyFruits
	} 

    // Score Negativo ativa o GameOver
    public void GameOverAtivado()
    {
        if (scoreValue < 0 && JaToquei == false)
        {
            StartCoroutine(EndGame());
            JaToquei = true;
        }
    }

    IEnumerator EndGame()
    {
        fruitSpawner.GetComponent<FruitSpawner>().DesligaSpawner();
        //am.GetComponent<AudioSource>().Stop();
        Time.timeScale = 0f;
        am.GetComponent<AudioSource>().Stop();
        am.GetComponent<InGameAudio>().GameOverClick();
        Destroy(GameObject.Find("FimDeJogo"));
        Destroy(GameObject.Find("timer"));
        Destroy(GameObject.Find("clock"));
        yield return new WaitForSecondsRealtime(am.GetComponent<InGameAudio>().ClipLenght(7) * 1.2f);      
        am.GetComponent<InGameAudio>().JacksonKnew();
        yield return new WaitForSecondsRealtime(am.GetComponent<InGameAudio>().ClipLenght(5));
        Time.timeScale = 1f;
        player.GetComponent<Animator>().SetBool("morreu", true);
        am.GetComponent<InGameAudio>().GritoGoofy();
        am.GetComponent<InGameAudio>().GameOverMusic();
        Destroy(player.GetComponent<PlayerControl>());
        Destroy(player.GetComponent<Collider2D>());
        player.GetComponent<Rigidbody2D>().freezeRotation = false;
        player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 50, ForceMode2D.Impulse);
        yield return new WaitForSecondsRealtime(am.GetComponent<InGameAudio>().ClipLenght(3));
        fimDeJogoNormal.SetActive(true);
        am.GetComponent<InGameAudio>().PosGameOverMusic();
    }
}
