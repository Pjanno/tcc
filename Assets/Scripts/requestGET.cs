using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class requestGET : MonoBehaviour {

    void Start()
    {
        StartCoroutine(GetText());
    }

    private string mensagem;

	public IEnumerator GetText()
    {
        UnityWebRequest wr = UnityWebRequest.Get("http://localhost:8000/api/item");
        yield return wr.SendWebRequest();

        if(wr.isNetworkError || wr.isHttpError)
        {
            Debug.Log(wr.error);
        }
        else
        {
            // Exibe o JSON no log
            Debug.Log(wr.downloadHandler.text);
            mensagem = wr.downloadHandler.text;
        }

    }

    public void EscreveSaporra()
    {

        print(mensagem);
    }
}
