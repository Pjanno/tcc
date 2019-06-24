using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPowerUp : MonoBehaviour {

    [SerializeField]
    private GameObject contadorRelogio;
    private GameObject audioManager;

    public static float valorTempo;

    

    void Start () {
        contadorRelogio = GameObject.Find("timer");
        audioManager = GameObject.Find("AudioManager");
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "Player")
        {
            contadorRelogio.GetComponent<MyTime>().AdicionaMaisTempo(valorTempo);
            audioManager.GetComponent<InGameAudio>().SomDoPowerUp();
            Destroy(this.gameObject);
        }
        if(c.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject, valorTempo/2);
        }
    }
}
