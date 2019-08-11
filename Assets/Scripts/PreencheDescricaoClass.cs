using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreencheDescricaoClass : MonoBehaviour {

    [SerializeField]
    private GameObject PainelConfirmacao;

    void Awake()
    {
        PainelConfirmacao = GameObject.Find("PainelConfirmacao");
    }

    void Update()
    {

    }

    public void PreencheDescricao()
    {
        var textoDaInformacao = this.gameObject.GetComponentsInChildren<Text>();
        if(PainelConfirmacao.GetComponent<InformacoesItens>() != null)
        {
            var informacoesDoItem = PainelConfirmacao.GetComponent<InformacoesItens>();
            if (informacoesDoItem != null)
            {
                switch (informacoesDoItem.item_id)
                {
                    case 1:
                        textoDaInformacao[1].text = "Speedog: Aumenta a velocidade base do nosso herói " +
                                                    "tornando a colheita de frutas mais veloz " +
                                                    "permitindo que você pegue até mesmo frutas que já estão no chão a uma distância maior.";
                        PlayerPrefs.SetString("PowerUp", "Speedog");
                        break;
                    case 2:
                        textoDaInformacao[1].text = "Time Ruler: Adiciona 15 segundos extras para a colheita. " +
                                                    "Isso torna a colheita das frutas mais interessante pra quem quer marcar um Score alto.";
                        PlayerPrefs.SetString("PowerUp", "TimeRuler");
                        break;
                }
            }
        }
    }
}
