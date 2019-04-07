using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyTime : MonoBehaviour {

	public int timeLeft = 60;
	public Text timer;
    public GameObject IconeRelogio;

	// Use this for initialization
	void Start () {
		StartCoroutine("LoseTime");
	}
	
	// Update is called once per frame
	void Update () {
		/* timer.text = ("Tempo: " + timeLeft);*/
		timer.text = ("" + timeLeft);

		if (timeLeft <= 0) {
			StopCoroutine("LoseTime");
			//timer.text = "Fim de Jogo!";
            
		} else if (timeLeft <= 10) {
			IconeRelogio.GetComponent<Animator>().SetBool("desperta", true);
		}
	}
	
	IEnumerator LoseTime() {
		while (true) {
			yield return new WaitForSeconds(1);
			timeLeft --;
		}
	}
}
