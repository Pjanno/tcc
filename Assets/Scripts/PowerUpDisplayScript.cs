using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpDisplayScript : MonoBehaviour {

	void Start()
    {
        this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        this.gameObject.transform.GetChild(2).gameObject.SetActive(false);

        if (PowerUp.quantidadeUso > 0)
        {
            if (PlayerPrefs.GetString("PowerUp") == "TimeRuler")
            {
                this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }
            if (PlayerPrefs.GetString("PowerUp") == "Speedog")
            {
                this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
            }
        }
    }
    void Update()
    {
        if (PowerUp.quantidadeUso == 0 || PowerUp.quantidadeUso < 0)
        {
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }
    }
}
