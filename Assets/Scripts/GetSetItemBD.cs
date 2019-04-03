using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetSetItemBD {

    public IEnumerator GetJsonFromBD()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://127.0.0.1:8000/api/inventario/items/1/"))
        {
            www.SetRequestHeader("Authorization", "Token "+PlayerPrefs.GetString("Token"));
            yield return www.SendWebRequest();

            if (www.isHttpError || www.isNetworkError) {
                Debug.Log(www.error);
            }
            else
            {
                JSONObject jObj = new JSONObject(www.downloadHandler.text);
                Debug.Log(jObj);
            }
        }
    }
}
