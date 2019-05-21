using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginStatusCheck : MonoBehaviour {

    void Update () {
        VerificaStatus();
	}

    public void VerificaStatus() {
        if (PlayerPrefs.HasKey("Logado")) {
            if(PlayerPrefs.GetInt("Logado") == 1) {
                this.gameObject.GetComponent<Image>().color = new Color(0, 1, 0);
                this.gameObject.GetComponentInChildren<Text>().text = "Online";
            }
            else if (PlayerPrefs.GetInt("Logado") == 0) {
                this.gameObject.GetComponent<Image>().color = new Color(1, 0, 0);
                this.gameObject.GetComponentInChildren<Text>().text = "Offline";
            }
            else {
                this.gameObject.SetActive(false);
            }
        }
    }
}
