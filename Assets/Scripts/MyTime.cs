using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyTime : MonoBehaviour {

	public int timeLeft = 60;
	public Text timer;
	// Use this for initialization
	void Start () {
		StartCoroutine("LoseTime");
	}
	
	// Update is called once per frame
	void Update () {
		timer.text = ("Time: " + timeLeft);

		if (timeLeft <= 0) {
			StopCoroutine("LoseTime");
			timer.text = "Times Up!";
		}
	}

	IEnumerator LoseTime() {
		while (true) {
			yield return new WaitForSeconds(1);
			timeLeft --;
		}
	}
}
