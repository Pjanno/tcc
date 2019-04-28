using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedStartScript : MonoBehaviour {

	public GameObject countDown, FruitSpawner, Canvas;
    
	// Use this for initialization
	void Start ()
    {
		StartCoroutine ("StartDelay");
	}

    // Update is called once per frame
    void Update()
    {

    }

	IEnumerator StartDelay ()
    {
        Canvas.GetComponent<PauseScript>().enabled = false;
		Time.timeScale = 0;
		float pauseTime = Time.realtimeSinceStartup + 3f;
		while (Time.realtimeSinceStartup < pauseTime)
			yield return 0;
		countDown.gameObject.SetActive (false);
        Time.timeScale = 1;
        FruitSpawner.GetComponent<FruitSpawner>().LigaSpawner();
        Canvas.GetComponent<PauseScript>().enabled = true;
    }
}
