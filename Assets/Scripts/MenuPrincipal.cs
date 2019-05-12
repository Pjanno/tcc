using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {

    public GameObject PainelSair, MainMenuPrincipal, PainelConfig, TransicaoImg;
    public AudioSource AudioSourceMenu;

    public void AtivaTransicao()
    {
        TransicaoImg.SetActive(true);
    }

    public void Awake()
    {
        Time.timeScale = 1;
        AudioSourceMenu.volume = PlayerPrefs.GetFloat("Volume");
    }

    public void Start()
    {
        //Aqui provavelmente só é ativado quando roda a primeira vez esse script na scene
        //então vamos inicializar o que é e o que não é pra ser visto
        PainelSair.SetActive(false);
    }
    
    public void Jogar()
    {
        StartCoroutine(AudioFadeOut.FadeOut(this.AudioSourceMenu, 1f));
        StartCoroutine(CarregarScene(1.5f, "PreStartJogo"));
    }
    public void Config()
    {
        MainMenuPrincipal.SetActive(false);
        PainelSair.SetActive(false); //Sei lá, vai que ativa com bug
        PainelConfig.SetActive(true);
    }
    public void Sair()
    {
        //Não sai efetivamente, pergunta primeiro com a outra box.
        MainMenuPrincipal.SetActive(false);
        PainelSair.SetActive(true);
    }
    public void SairEfetivo()
    {
        StartCoroutine(SairAplicacao(1.5f));
    }
    public void Voltar()
    {
        MainMenuPrincipal.SetActive(true);
        PainelConfig.SetActive(false);
        PainelSair.SetActive(false);
    }

    // PARTE SONORA DO MENU SFX ========================================================
    public AudioClip[] sfx = new AudioClip[4]; // 0 = Click
                                               // 1 = Hover
                                               // 2 = Back
                                               // 3 = Exit
    public void Click()
    {
        AudioSourceMenu.Pause();
        AudioSourceMenu.PlayOneShot(sfx[0]);
    }
    public void Hover()
    {
        AudioSourceMenu.Pause();
        AudioSourceMenu.PlayOneShot(sfx[1]);
    }
    public void Back()
    {
        AudioSourceMenu.Pause();
        AudioSourceMenu.PlayOneShot(sfx[2]);
    }
    public void Exit()
    {
        AudioSourceMenu.Pause();
        AudioSourceMenu.PlayOneShot(sfx[3]);
    }
    
    // COROUTINES ÚTEIS PARA AS ANIMAÇÕES AND SHIT LIKE THAT ==========================
    IEnumerator CarregarScene(float tempo, string nomeScene)
    {
        Debug.Log("Estou aguardando " + tempo + " segundos para pular de linha");
        yield return new WaitForSeconds(tempo);
        Debug.Log("Pronto!");
        SceneManager.LoadScene(nomeScene);
    }

    IEnumerator SairAplicacao (float segundos)
    {
        Debug.Log("Recebi o tempo de " + segundos + " segundos para fechar");
        yield return new WaitForSeconds(segundos);
        Application.Quit();
    }
}
