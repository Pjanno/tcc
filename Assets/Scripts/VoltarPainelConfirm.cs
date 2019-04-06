using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoltarPainelConfirm : MonoBehaviour
{
    public GameObject target;

    public void VoltarPraTelaDeConfirmacao()
    {
        target.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
