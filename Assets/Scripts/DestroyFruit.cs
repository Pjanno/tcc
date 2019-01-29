using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFruit : MonoBehaviour {

private GameObject[] Fruits;
	
void Update () { 
	Destroy(gameObject, 6f); 
	//Destroy Gameobject, after 2 Seconds. } 
}

private void OnCollisionEnter2D(Collision2D collision) { 
	if(collision.gameObject.tag == "Ground") { 
		//Destroy(gameObject); 
		//Just destroy Gameobject, without delay. 
		Destroy(gameObject, 6f); // Destroy GameObject after 5 Seconds. 
	} 
	if (collision.gameObject.tag == "Player") {
		Destroy(gameObject);
		Score.scoreValue += 1;
	} 
}  
}
