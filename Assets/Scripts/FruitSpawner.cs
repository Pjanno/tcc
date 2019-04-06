using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject Frutas;

    int IdFruta;
    private BoxCollider2D col;
	
	float x1, x2;

    void Awake () {
		col = GetComponent<BoxCollider2D> ();
		
		x1 = transform.position.x - col.bounds.size.x /2f;
		x2 = transform.position.x + col.bounds.size.x /2f;
	}


    void Start()
    {
        StartCoroutine(SpawnFruit(3f));
    }

    void Update()
    {
        // Aleatoriza a imagem automaticamente
        IdFruta = Random.Range(0, 5);
        Frutas.GetComponent<SpriteRenderer>().sprite = Frutas.transform.GetChild(IdFruta).GetComponent<SpriteRenderer>().sprite;

    }

  	IEnumerator SpawnFruit(float time) {
		yield return new WaitForSecondsRealtime (time);
		
		Vector3 temp = transform.position;
		temp.x = Random.Range (x1, x2);

        // Range pra fruta selecionar uma imagem aleatória:
        
        Instantiate (Frutas, temp, Quaternion.identity);
		
		StartCoroutine (SpawnFruit(Random.Range(0.7f, 0.7f))); //vai spawnar fruta a cada 0.7 segundos
	}
}
