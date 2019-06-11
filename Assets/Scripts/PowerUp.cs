﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public static int quantidadeUso = 0;
    private GameObject contador, jogador;
	// Use this for initialization
    void Awake()
    {
        contador = GameObject.Find("timer");
        jogador = GameObject.Find("Player");
    }

	void Start () {
        if (PlayerPrefs.GetInt("quantidadeTemp") == 0)
        {
            quantidadeUso = 0;
        } else
        {
            quantidadeUso = 1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        UsarPowerUp();
	}

    public void UsarPowerUp()
    {
        if(Input.GetKeyDown(KeyCode.E) && quantidadeUso >= 1)
        {
            quantidadeUso -= 1;
            PowerUpPraUsar(PlayerPrefs.GetString("PowerUp"));
        }
    }

    public void PowerUpPraUsar(string s)
    {
        switch (s)
        {
            case "TimeRuler":
                {
                    Debug.Log("Incrementei o tempo por 15 segundos");
                    this.contador.GetComponent<MyTime>().AdicionaMaisTempo(15);
                    break;
                }
            case "RedShoes":
                {
                    Debug.Log("Subi a velocidade pra 10 pontos por 15 segundos");
                    this.jogador.GetComponent<PlayerControl>().AumentarVelocidadeTemp(10, 15);
                    break;
                }
        }
    }
}