using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour {

    public GameObject PainelSair, MainMenuPrincipal, PainelConfig, TransicaoImg, JanelaAviso;
    public AudioSource AudioSourceMenu;
    public DataCollection ListaDeItens = new DataCollection();
    [SerializeField]
    private string nomeDaScene;

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
        JanelaAviso.SetActive(false);
    }
    
    public void Jogar()
    {
        VerificaSeTemItensPraUsar();
        StartCoroutine(AudioFadeOut.FadeOut(this.AudioSourceMenu, 1f));
        StartCoroutine(CarregarScene(1.5f));
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
    IEnumerator CarregarScene(float tempo)
    {
        Debug.Log("Estou aguardando " + tempo + " segundos para pular de linha");
        yield return new WaitForSeconds(tempo);
        Debug.Log("Pronto!");
        SceneManager.LoadScene(this.nomeDaScene);
    }

    IEnumerator SairAplicacao (float segundos)
    {
        Debug.Log("Recebi o tempo de " + segundos + " segundos para fechar");
        yield return new WaitForSeconds(segundos);
        Application.Quit();
    }

    public void VerificaSeTemItensPraUsar()
    {
        // Se o player estiver logado [0 - deslogado / 1 - logado]
        if (PlayerPrefs.HasKey("Logado"))
        {
            if (PlayerPrefs.GetInt("Logado") == 1)
            {
                StartCoroutine(ObtemListaItens(PlayerPrefs.GetString("Token"), PlayerPrefs.GetInt("ID")));
            }
            else if (PlayerPrefs.GetInt("Logado") == 0)
            {
                this.nomeDaScene = "Level01";
            }
            else
            {
                this.nomeDaScene = "Level01";
            }
        }
    }

    public IEnumerator ObtemListaItens(string token, int user)
    {
        UnityWebRequest www = UnityWebRequest.Get("http://127.0.0.1:8000/api/inventario/items/" + user + "/");
        www.SetRequestHeader("Authorization", "Token " + token);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            ListaDeItens = JsonUtility.FromJson<DataCollection>(www.downloadHandler.text);
            List<data> data = new List<data>();
            data = ListaDeItens.data;

            Debug.Log(data.Count);

            if (data.Count <= 0)
            {
                JanelaAviso.SetActive(true);
                JanelaAviso.GetComponentInChildren<Text>().text = "Você não possui itens para gastar. Estamos te direcionando diretamente para o jogo principal.";
                this.nomeDaScene = "Level01";
            }
            else if (data.Count > 0)
            {
                JanelaAviso.SetActive(true);
                JanelaAviso.GetComponentInChildren<Text>().text = "Você está sendo direcionado para a seleção de itens.";
                this.nomeDaScene = "PreStartJogo";
            }
            else
            {
                JanelaAviso.SetActive(true);
                JanelaAviso.GetComponentInChildren<Text>().text = "Você não está logado, estamos te direcionando para o jogo principal.";
                this.nomeDaScene = "Level01";
            }
        }
    }
}
