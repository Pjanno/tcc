using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginRequest : MonoBehaviour {

    GameObject email, senha;
    public GameObject LoginHolder, LoadingHolder, InfoMessageHolder, TransitionLogin;

    void Awake()
    {
        
    }

    void Start() {
        if (PlayerPrefs.HasKey("Logado"))
        {
            PlayerPrefs.SetInt("Logado", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Logado", 0);
        }
    }

    // Update is called once per frame
    void Update() {

    }

    //JSON UTILITY
    TokenID meuToken = new TokenID();

    //COROUTINE do Request pro ID e TOKEN
    private string mensagem;

    public IEnumerator Login(string email, string senha)
    {
        ///Cria o formulário com os campos a serem enviados
        WWWForm form = new WWWForm();
        form.AddField("username", email);
        form.AddField("password", senha);

        //Faz o POST
        using (UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:8000/api/auth/login/", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                //Se deu erro desativa o loading e ativa o mensagem de erro
                LoadingHolder.SetActive(false);
                InfoMessageHolder.SetActive(true);
                InfoMessageHolder.transform.GetChild(1).GetComponentInChildren<Text>().text = www.error;
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                yield return www.downloadHandler.text;
                meuToken = JsonUtility.FromJson<TokenID>(www.downloadHandler.text);

                // Substitui os Tokens e Ids informados pelo usuário
                PlayerPrefs.SetString("Token", meuToken.key);
                PlayerPrefs.SetInt("ID", meuToken.user);
                
                PlayerPrefs.SetInt("Logado", 1);
                StartCoroutine(CarregaSceneNova("TeamLogo", 0f));
            }
        }
    }

    //REQUEST
    private void instanciaObjetos()
    {
        email = GameObject.FindGameObjectWithTag("email");
        senha = GameObject.FindGameObjectWithTag("senha");
    }

    public void EnviaDados()
    {
        instanciaObjetos();
        string e, s;
        e = this.email.GetComponent<InputField>().text;
        s = this.senha.GetComponent<InputField>().text;

        Debug.Log(e);
        Debug.Log(s);

        //Desativa o menu anterior e ativa o loading animado
        LoginHolder.SetActive(false);
        LoadingHolder.SetActive(true);

        //Faz o request
        StartCoroutine(Login(e, s));
        Debug.Log("So far so good");
    }
    
    //PRE MENU
    [SerializeField]
    GameObject PreMenuHolder;

    public void Nao()
    {
        PreMenuHolder.GetComponent<Animator>().SetBool("reverse", true);
        TransitionLogin.GetComponent<Animator>().SetBool("fadeOut", true);
    }

    public void TransitaProximaScene()
    {
        StartCoroutine(CarregaSceneNova("TeamLogo", 0f));
    }

    public void Sim()
    {
        PreMenuHolder.GetComponent<Animator>().SetBool("reverse", true);
        StartCoroutine(WaitTimeAnimation(1.1f));
        PreMenuHolder.SetActive(false);        
        LoginHolder.SetActive(true);
    }

    IEnumerator WaitTimeAnimation(float f)
    {
        yield return new WaitForSeconds(f);
        Debug.Log("Waiting " + f + " seconds");
    }

    IEnumerator CarregaSceneNova(string scene, float tempoEspera)
    {
        yield return new WaitForSeconds(tempoEspera);
        SceneManager.LoadScene(scene);
    }

    //MOCK AREA 51
    public void MockDasEras()
    {
        StartCoroutine(Login2("admin", "admin"));
    }

    public IEnumerator Login2(string email, string senha)
    {
        ///Cria o formulário com os campos a serem enviados
        WWWForm form = new WWWForm();
        form.AddField("username", email);
        form.AddField("password", senha);

        //Faz o POST
        using (UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:8000/api/auth/login/", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

                meuToken = JsonUtility.FromJson<TokenID>(www.downloadHandler.text);

                Debug.Log(meuToken.key);

                yield return www.downloadHandler.text;

                if (PlayerPrefs.HasKey("Token"))
                {
                    PlayerPrefs.SetString("Token", meuToken.key);
                }
                else
                {
                    PlayerPrefs.SetString("Token", meuToken.key);
                    PlayerPrefs.SetInt("ID", meuToken.user);
                }
                

                GetSetItemBD gsi = new GetSetItemBD();
                StartCoroutine(gsi.GetJsonFromBD());
            }
        }
    }
}
