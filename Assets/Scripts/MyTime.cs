using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MyTime : MonoBehaviour {

    public float tempoInicial;
	public static float timeLeft;
    public GameObject IconeRelogio;

    [SerializeField]
    private GameObject fimDeJogoCanvas;

    public UnityEvent FimDoTempo;
    public UnityEvent TempoAcabandoComMusica;
    public UnityEvent TempoAcabando;

    bool jahRodei;

    float qtdPowerup = 1;

    // Use this for initialization
    void Start () {
		StartCoroutine("LoseTime");
        jahRodei = false;
        timeLeft = tempoInicial;
	}    

	// Update is called once per frame
	void Update () {

		this.gameObject.GetComponent<Text>().text = "" + timeLeft;

        
        if (timeLeft <= 18.681f)
        {
            if (!jahRodei)
            {
                if (PowerUp.quantidadeUso == 0)
                {
                    TempoAcabandoComMusica.Invoke();
                }
                else
                {
                    TempoAcabando.Invoke();
                }
                IconeRelogio.GetComponent<Animator>().SetBool("desperta", true);
                jahRodei = true;
            }
        }               
        
        if (timeLeft <= 0f) {
            StopCoroutine("LoseTime");
            IconeRelogio.GetComponent<Animator>().SetBool("desperta", false);
            FimDoTempo.Invoke();
        }
	}
	
	IEnumerator LoseTime() {
		while (true) {
			yield return new WaitForSeconds(1f);
			timeLeft --;
		}
	}

    public void AdicionaMaisTempo(float i)
    {
        timeLeft += i;
    }

    public void RemoveUmTempo(float i)
    {
        timeLeft -= i;
    }
}
