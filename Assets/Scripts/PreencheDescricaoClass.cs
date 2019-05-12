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
                    case 0:
                        textoDaInformacao[1].text = "Pumper: Faz a velocidade do nosso herói ficar um pouco frenética. " +
                                                    "Isso torna a colheita das frutas um pouco mais veloz por um curto período de tempo.";
                        break;
                    case 1:
                        textoDaInformacao[1].text = "Fruit Frenzy: A mãe natureza resolveu te dar uma força na colheita e a Árvore Anciã " +
                                                    "se fortaleceu tanto que os frutos crescem e caem com muito mais frequência " +
                                                    "durante um curto período de tempo.";
                        break;
                }
            }
        }
    }
}
