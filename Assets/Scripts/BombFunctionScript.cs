using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFunctionScript : MonoBehaviour {

    [SerializeField]
    GameObject audioManager;
    [SerializeField]
    GameObject player;

    void Start()
    {
        audioManager = GameObject.Find("AudioManager");
        player = GameObject.Find("Player");
    }

	void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            Score.scoreValue -= 5;
            audioManager.GetComponent<InGameAudio>().BombSound();
            player.GetComponent<Animator>().SetBool("hit", true);
            Destroy(this.gameObject);
        }
        if (c.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject, 2f);
        }
    }

}
