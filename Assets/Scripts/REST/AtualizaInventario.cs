using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AtualizaInventario : MonoBehaviour, IPointerEnterHandler{
    [SerializeField]
    private GameObject PainelConfirmacao;
    [SerializeField]
    private GameObject PainelInformacoesItem;

    public void Awake()
    {
        PainelConfirmacao = GameObject.Find("PainelConfirmacao");
        PainelInformacoesItem = GameObject.Find("PainelInformacoesItem");
    }

    public void Start()
    {
        PainelConfirmacao.SetActive(false);
    }
    
    void Update()
    {

    }

    public void PassaAhDescricao()
    {
        if (PainelConfirmacao.GetComponent<InformacoesItens>() != null)
        {
            PainelConfirmacao.GetComponent<InformacoesItens>().item_id = this.GetComponent<InformacoesItens>().item_id;
            PainelConfirmacao.GetComponent<InformacoesItens>().quantidade = this.GetComponent<InformacoesItens>().quantidade;
        }
        else
        {
            PainelConfirmacao.AddComponent<InformacoesItens>();
            PainelConfirmacao.GetComponent<InformacoesItens>().item_id = this.GetComponent<InformacoesItens>().item_id;
            PainelConfirmacao.GetComponent<InformacoesItens>().quantidade = this.GetComponent<InformacoesItens>().quantidade;
        }
        PainelInformacoesItem.GetComponent<PreencheDescricaoClass>().PreencheDescricao();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PassaAhDescricao();
    }
}
