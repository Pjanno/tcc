using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoltaTelaLogin : MonoBehaviour {

    public GameObject Painel;
	public void AtivaPainelLogin()
    {
        Painel.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
