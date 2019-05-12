using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThisObj : MonoBehaviour {

	public void DestroyThis()
    {
        GameObject.Destroy(gameObject);
    }
}
