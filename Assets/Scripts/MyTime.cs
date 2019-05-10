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

	float qtd_powerup = 1;

	public GameObject Button_Powerup; // ou public Button Button_Powerup;


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
        } else {
			usaPowerup();
		}
	}

	public void usaPowerup() {
		if ( (Input.GetMouseButtonDown(0)) && (qtd_powerup > 0) ) 
        {
            timeLeft = timeLeft + 15;
			qtd_powerup = qtd_powerup - 1;
			Time.timeScale = 1f;
			Button_Powerup.SetActive(false); // ou Button_Powerup.gameObject.SetActive(false);
			
	    }
	}
	
	IEnumerator LoseTime() {
		while (true) {
			yield return new WaitForSeconds(1);
			timeLeft --;
		}
	}
}
