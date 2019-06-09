using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSound : MonoBehaviour {

    public AudioClip ac;

	public void JumpSoundPlay()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(ac);
    }
}
