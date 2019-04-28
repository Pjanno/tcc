using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MyTime : MonoBehaviour {

	public int timeLeft;
	public Text timer;
    public GameObject IconeRelogio;

    public UnityEvent FimDoTempo;


    // Use this for initialization
    void Start () {
		StartCoroutine("LoseTime");
	}    

	// Update is called once per frame
	void Update () {
		timer.text = ("" + timeLeft);

        if (timeLeft <= 10)
        {
            IconeRelogio.GetComponent<Animator>().SetBool("desperta", true);
        }
        if (timeLeft <= 0) {
            StopCoroutine("LoseTime");
            FimDoTempo.Invoke();
        }
	}
	
	IEnumerator LoseTime() {
		while (true) {
			yield return new WaitForSeconds(1);
			timeLeft --;
		}
	}
}
