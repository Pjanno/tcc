using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameAudio : MonoBehaviour {

    [SerializeField]
    private AudioClip[] ac;

    void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            this.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
        } else
        {
            this.gameObject.GetComponent<AudioSource>().volume = 80f;
        }
    }

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
        AudioFadeOut.FadeOut(this.gameObject.GetComponent<AudioSource>(), 1f);
        new WaitForSecondsRealtime(1f);
        this.gameObject.GetComponent<AudioSource>().Stop();
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(ac[2]);

    }
    public void GritoGoofy()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(ac[3]);

    }
    public void BombSound()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(ac[4]);

    }
    public void JacksonKnew()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(ac[5]);

    }
    public void JustToSuffer()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(ac[6]);

    }
    public void GameOverClick()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(ac[7]);

    }
    public void GameOverMusic()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(ac[8]);

    }
    public void PosGameOverMusic()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(ac[9]);

    }
    public void ChineseChime()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(ac[10]);

    }
    public float ClipLenght(int n)
    {
        return ac[n].length;
    }
}
