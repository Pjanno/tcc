using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject Frutas;
    [SerializeField]
    private GameObject Timer;
    [SerializeField]
    private GameObject Bomb;
    [SerializeField]
    private int frequencia;
    [SerializeField]
    private int frequenciaBombas;

    int IdFruta;
    private BoxCollider2D col;
    IEnumerator Spawner;
    float x1, x2;

    void Awake ()
    {
		col = GetComponent<BoxCollider2D> ();
		x1 = transform.position.x - col.bounds.size.x /2f;
		x2 = transform.position.x + col.bounds.size.x /2f;
        Spawner = SpawnFruit(0.7f);
    }

    void Update()
    {
        // Aleatoriza a imagem automaticamente
        IdFruta = Random.Range(0, 5);
        Frutas.GetComponent<SpriteRenderer>().sprite = Frutas.transform.GetChild(IdFruta).GetComponent<SpriteRenderer>().sprite;

    }

    // AQUI COMEÇA AS COISAS Só DO SPAWNER
  	IEnumerator SpawnFruit(float time)
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(time);

            Vector3 temp = transform.position;
            temp.x = Random.Range(x1, x2);

            //Cadeia de Spawns
            if (Random.Range(1, this.frequencia) == Random.Range(1, this.frequencia))
            {
                // Spawn dos relógios
                if (MyTime.timeLeft >= 18.681f + TimerPowerUp.valorTempo * 2)
                {
                    Instantiate(Timer, temp, Quaternion.identity);
                }
            }
            else if (Random.Range(1, this.frequenciaBombas) == Random.Range(1, this.frequenciaBombas))
            {
                // Spawn das bombas
                if (MyTime.timeLeft >= 18.681f + TimerPowerUp.valorTempo * 2)
                {
                    Instantiate(Bomb, temp, Quaternion.identity);
                }
            }
            else
            {
                Instantiate(Frutas, temp, Quaternion.identity);
            }
        }
	}
    public void LigaSpawner()
    {
        StartCoroutine(Spawner);
    }
    public void DesligaSpawner()
    {
        StopCoroutine(Spawner);
    }
}
