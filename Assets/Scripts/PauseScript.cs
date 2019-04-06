using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

	bool isPause;
	void Pause() {
		Time.timeScale = 0;
	}

	void UnPause() {
		Time.timeScale = 1;
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.P)) {
			isPause = !isPause;
			
			if (isPause) {
				Pause ();
			} else {
				UnPause (); 
			}
		}
	}
}
