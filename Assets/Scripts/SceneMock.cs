using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMock : MonoBehaviour {
    [SerializeField]
    private string nomeDaScene;

    public void ProximaScene()
    {
        SceneManager.LoadScene(nomeDaScene);
    }
}
