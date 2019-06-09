using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPowerUp : MonoBehaviour {

    [SerializeField]
    private GameObject contadorRelogio;
    [SerializeField]
    private AudioSource aSourceLocal;
    
    public static float valorTempo;

    public AudioClip somDaFruta;

    void Start () {
        contadorRelogio = GameObject.Find("timer");
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    IEnumerator TocaSomDaFruta()
    {
        aSourceLocal.PlayOneShot(somDaFruta);
        yield return new WaitForSeconds(somDaFruta.length);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "Player")
        {
            contadorRelogio.GetComponent<MyTime>().AdicionaMaisTempo(valorTempo);
            StartCoroutine(TocaSomDaFruta());
            Destroy(this.gameObject);
        }
        if(c.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject, valorTempo/2);
        }
    }
}
