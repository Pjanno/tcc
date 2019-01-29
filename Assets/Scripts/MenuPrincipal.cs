using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {

    public GameObject boxSair, menuPrincipal;

    public void Start()
    {
        //Aqui provavelmente só é ativado quando roda a primeira vez esse script na scene
        //então vamos inicializar o que é e o que não é pra ser visto
        boxSair.SetActive(false);
    }
    
    public void Jogar()
    {
        SceneManager.LoadScene("Level01", LoadSceneMode.Single);
    }
    public static void Config()
    {
        
    }
    public void Sair()
    {
        //Não sai efetivamente, pergunta primeiro com a outra box.
        menuPrincipal.SetActive(false);
        boxSair.SetActive(true);
    }
    public void SairEfetivo()
    {
        Application.Quit();
    }
    public void Voltar()
    {
        menuPrincipal.SetActive(true);
        boxSair.SetActive(false);
    }
}
