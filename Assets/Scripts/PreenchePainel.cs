using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PreenchePainel : MonoBehaviour {

    TokenID meuToken = new TokenID();
    public DataCollection ListaDeItens = new DataCollection();
    public AudioSource AudioSourceScene;
    public GameObject PrefabLista;
    public GameObject Painel;
    [SerializeField]
    protected GameObject PainelConfirmacao;

    //====================================================
    public void Awake()
    {
        Painel = GameObject.FindGameObjectWithTag("Painel");
        PainelConfirmacao = GameObject.Find("PainelConfirmacao");
    }

    public void Start()
    {
        ListarItens();
    }

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
                Debug.Log(www.error);
            }
            else
            {
                meuToken = JsonUtility.FromJson<TokenID>(www.downloadHandler.text);

                yield return www.downloadHandler.text;

                if (PlayerPrefs.HasKey("Token"))
                {
                    PlayerPrefs.SetString("Token", meuToken.key);
                } 
                if (PlayerPrefs.HasKey("ID"))
                {
                    PlayerPrefs.SetInt("ID", meuToken.user);
                }
                else
                {
                    PlayerPrefs.SetString("Token", meuToken.key);
                    PlayerPrefs.SetInt("ID", meuToken.user);
                }
            }
        }
    }

    // MOCK DO INVENTARIO
    public void ListarItens()
    {
        StartCoroutine(ObtemListaItens(PlayerPrefs.GetString("Token"), PlayerPrefs.GetInt("ID")));
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
            PreenchePainelComLista();
        }
    }

    public void PreenchePainelComLista()
    {
        foreach (data data in ListaDeItens.data)
        {
            GameObject go = PrefabLista;
            var Textos = go.GetComponentsInChildren<Text>();
            Textos[0].text = data.nome_item;
            Textos[1].text = data.quantidade.ToString();
            go.GetComponent<InformacoesItens>().item_id = data.item_id;
            go.GetComponent<InformacoesItens>().quantidade = data.quantidade;
            go = Instantiate(PrefabLista, Painel.transform);
        }
    }

    // CHAMADAS DO PAINEL
    public void DesisteDeUsar()
    {
        PainelConfirmacao.SetActive(false);
    }

    public void ChamadaPut()
    {
        
        StartCoroutine(AudioFadeOut.FadeOut(this.AudioSourceScene, 1f));
        StartCoroutine(AtualizaItem());
    }

    public void ConfirmaUso()
    {
        PainelConfirmacao.SetActive(true);
    }

    public IEnumerator AtualizaItem()
    {
        int quantidadeNova = PainelConfirmacao.GetComponent<InformacoesItens>().quantidade;
        quantidadeNova -= 1;
        int idDoItem = PainelConfirmacao.GetComponent<InformacoesItens>().item_id;
        int idDoPlayer = PlayerPrefs.GetInt("ID");

        string link = "http://127.0.0.1:8000/api/inventario/" + idDoPlayer.ToString() + "/" + idDoItem.ToString() + "/?quantidade=" + quantidadeNova.ToString();

        byte[] myData = System.Text.Encoding.UTF8.GetBytes(".");

        UnityWebRequest www = UnityWebRequest.Put(link, myData);
        Debug.Log(PlayerPrefs.GetString("Token"));
        www.SetRequestHeader("Authorization", "Token " + PlayerPrefs.GetString("Token"));

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            // Aqui vai entrar a animação de log de erro
        }
        else
        {
            PainelConfirmacao.GetComponent<Animator>().SetBool("confirmou", true);
            Debug.Log("Funcionou");
            PlayerPrefs.SetInt("quantidadeTemp", 1);
            // Aqui vai entrar o controller da animação
        }
    }
}
