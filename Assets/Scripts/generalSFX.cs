using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generalSFX : MonoBehaviour {

    public AudioSource sfx;
    public AudioClip[] clp = new AudioClip[5]; //Setei como 5 audios somente
    
    
    public void Start()
    {
        sfx.Stop(); //Pra não ter risco de tocar nada aleatório no começo
    }

    //Toca o audio do vetor com o parametro passado
    public void StopAndPlaySfx(int i) 
    {
        sfx.Stop();
        sfx.PlayOneShot(clp[i]);
    }

    //Toca o audio do vetor sem pausar o anterior
    public void PlaySfx(int i)
    {
        sfx.Stop();
        sfx.PlayOneShot(clp[i]);
    }
}
