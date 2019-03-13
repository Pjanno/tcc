using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AjusteVolume : MonoBehaviour {

    AudioSource VolumeScene;
    [SerializeField]
    private Slider barraVolume;

    // Use this for initialization
    void Start ()
    {
        VolumeScene = gameObject.GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("Volume"))
        {
            VolumeScene.volume = PlayerPrefs.GetFloat("Volume");
            barraVolume.value = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            VolumeScene.volume = 1;
        }
        barraVolume.maxValue = 1;
        barraVolume.minValue = 0;
        PlayerPrefs.GetFloat("Volume");
    }

    // Update is called once per frame
    public void AtribuiVolume ()
    {
        VolumeScene.GetComponent<AudioSource>().volume = barraVolume.value;
        PlayerPrefs.SetFloat("Volume", barraVolume.value);
    }

    void Update ()
    {
        
    }
}
