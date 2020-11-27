using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    private AudioSource AudioSrc;

    private float AudioVolume = 1f;

    private static Volume instance;

    void Awake()
    {

        if (instance is null)
        {
            instance = this;
            AudioSrc = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

    }

    void Start()
    {
        AudioSrc = GetComponent<AudioSource>();
        GetVolume();

        Slider slider = FindObjectOfType<Slider>();

        if (slider)
        {
            slider.value = GetVolume();
        }

        SoundManager sm = FindObjectOfType<SoundManager>();
        if (sm)
            Destroy(sm.gameObject);
    }

    static public void DestroyThisObject()
    {
        if(instance)
            Destroy(instance.gameObject);
        instance = null;
    }

    public void SetVolume(Slider slider)
    {
        PlayerPrefs.SetFloat("volume", slider.value);
        PlayerPrefs.Save();
        AudioSrc.volume = slider.value;
    }

    private float GetVolume()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1f);
            PlayerPrefs.Save();
        }

        AudioSrc.volume = PlayerPrefs.GetFloat("volume");

        Debug.Log(PlayerPrefs.GetFloat("volume"));
        return PlayerPrefs.GetFloat("volume");

    }
}