using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyFruit : MonoBehaviour {

    private GameObject[] Fruits;

    private GameObject audioManager;

    void Start()
    {
        audioManager = GameObject.Find("AudioManager");
    }
	
    void Update () { 
	//Destroy(gameObject, 3f); 
	//Se ativar a linha acima, a fruta vai ser destruida x segundos após seu spawn, independente da colisão com qualquer outro objeto. 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
	    if(collision.gameObject.tag == "Ground") { 
		    //Destroy(gameObject); Se ativado, iria destruir a fruta instantaneamente após a colisão com o objeto de tag Ground.
		    Destroy(gameObject, 1f); //Vai destruir a fruta depois de 1 segundo após a colisão com o objeto de tag Ground. 
	    } 
	    if ((collision.gameObject.tag == "Player") || (collision.gameObject.tag == "NPC"))
        {
            audioManager.GetComponent<InGameAudio>().SomDaFruta();
		    Destroy(gameObject); //Destroi a fruta instantaneamente após colisão com o Player.
		    Score.scoreValue += 1;
	    } 
    }  
}
