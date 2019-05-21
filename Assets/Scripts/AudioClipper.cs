using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipper : MonoBehaviour {
    [SerializeField]
    private AudioSource aSource;

    public AudioClip[] clips;

    public void PressOkSound()
    {
        this.aSource.PlayOneShot(clips[0]);
    }

    public void PressNoSound()
    {
        this.aSource.PlayOneShot(clips[1]);
    }

    public void DoneSound()
    {
        this.aSource.PlayOneShot(clips[2]);
    }

    public void TextChangeSound()
    {
        this.aSource.PlayOneShot(clips[3]);
    }

}
