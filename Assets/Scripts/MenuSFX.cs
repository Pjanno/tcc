using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSFX : MonoBehaviour {
	public AudioSource sfx;
	public AudioClip click;
	public AudioClip hover;
	public AudioClip back;
	public AudioClip exit;

	public void Click(){
		sfx.Pause();
		sfx.PlayOneShot(click);
	}
	public void Hover(){
		sfx.Pause();
		sfx.PlayOneShot(hover);
	}
	public void Back(){
		sfx.Pause();
		sfx.PlayOneShot(back);
	}
	public void Exit(){
		sfx.Pause();
		sfx.PlayOneShot(exit);
	}
}
