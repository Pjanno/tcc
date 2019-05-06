using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PreenchePainel : MonoBehaviour {

    TokenID meuToken = new TokenID();
    public DataCollection ListaDeItens = new DataCollection();
    public GameObject PrefabLista;
    public GameObject Painel;

    //====================================================
    public void Awake()
    {
        Painel = GameObject.FindGameObjectWithTag("Painel");
    }

    public void Start()
    {
        MockDasEras();
        ListarItens();
    }

    // MOCK DO LOGIN
    public void MockDasEras()
    {
        StartCoroutine(Login("Felipe", "F3l1p3"));
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
        foreach(data data in ListaDeItens.data)
        {
            GameObject go = PrefabLista;
            var Textos = go.GetComponentsInChildren<Text>();
            Textos[0].text = data.nome_item;
            Textos[1].text = data.quantidade.ToString();
            go = Instantiate(PrefabLista, Painel.transform);
        }
        
    }
}
