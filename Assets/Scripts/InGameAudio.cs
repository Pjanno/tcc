using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameAudio : MonoBehaviour {

    [SerializeField]
    private AudioClip[] ac;

    public void SomDaFruta()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(ac[0]);

    }
    public void SomDoPowerUp()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(ac[1]);

    }
    public void MusicaSegundosFinais()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(ac[2]);

    }
}
