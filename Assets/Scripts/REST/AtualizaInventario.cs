using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AtualizaInventario : MonoBehaviour {
    [SerializeField]
    private GameObject PainelConfirmacao;

    public void Awake()
    {
        PainelConfirmacao = GameObject.Find("PainelConfirmacao");
    }

    public void Start()
    {
        PainelConfirmacao.SetActive(false);
    }
    
    void Update()
    {
        ConfirmaUsoItem();
    }

    private void ConfirmaUsoItem()
    {
        if (Input.GetMouseButtonDown(0) && (PainelConfirmacao.activeSelf == false))
        {
            PainelConfirmacao.SetActive(true);
            PainelConfirmacao.AddComponent<InformacoesItens>();
            PainelConfirmacao.GetComponent<InformacoesItens>().item_id = this.GetComponent<InformacoesItens>().item_id;
            PainelConfirmacao.GetComponent<InformacoesItens>().quantidade = this.GetComponent<InformacoesItens>().quantidade;
        }
    }
}
