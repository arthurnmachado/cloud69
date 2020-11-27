using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    public AudioSource backgroundAudioSrc, defaultShotAudioSrc;
    public float fadeTime = 0.5f,
                 defaultBackgroundVolume = 1f;

    private static SoundManager soundManager;
    private bool hasBackgroundAudioSrc, hasOneShotAudioSrc;
    private AudioMixer backgroundMixer;
    public string volumeMain;

    public static SoundManager instance
    {
        get
        {

            if (!soundManager)
            {
                soundManager = FindObjectOfType<SoundManager>() as SoundManager;

                if (soundManager is null)
                {
                    Debug.Log("There needs to be one active SoundManager script on a GameObject in your scene.");
                }
                else
                {
                    DontDestroyOnLoad(soundManager);
                    soundManager.Init();
                }


            }

            return soundManager;
        }
    }

    void Awake()
    {
        if (soundManager)
            Destroy(gameObject);
        else if (SoundManager.instance)
        {
            //pass
        }

    }

    private void Init()
    {
        // Temos um audio source de background?
        hasBackgroundAudioSrc = backgroundAudioSrc != null;
        // Temos um audio source de Sons unicos?
        hasOneShotAudioSrc = defaultShotAudioSrc != null;

        if (hasBackgroundAudioSrc)
        {
            backgroundMixer = backgroundAudioSrc.outputAudioMixerGroup.audioMixer;
            //bool returnB = backgroundMixer.SetFloat(volumeMain, - 80f);
            GetVolume();
        }

        Volume.DestroyThisObject();


    }

    private void Start()
    {
        Slider slider = FindObjectOfType<Slider>();
        
        if (slider)
        {
            slider.value = GetVolume();
        }
    }

    public void PlaySound(AudioClip sound)
    {

        if (instance.defaultShotAudioSrc.isPlaying)
        {
            instance.defaultShotAudioSrc.Stop();
            instance.StopAllCoroutines();
        }

        if (instance.hasBackgroundAudioSrc)
        {
            // Tem musica de fundo
            instance.defaultShotAudioSrc.clip = sound;
            instance.defaultShotAudioSrc.PlayDelayed(fadeTime);

            // Criar uma rotina para executar o fadeIn e FadeOut
            StartCoroutine(FadeAudioMixer.StartFade(instance.backgroundMixer, volumeMain, instance.fadeTime, 0f));
            StartCoroutine(FadeAudioMixer.StartFade(instance.backgroundMixer, volumeMain, instance.fadeTime, 1f, instance.fadeTime + sound.length));
        }
        else
        {
            // Nao tem musica de fundo
            instance.defaultShotAudioSrc.PlayOneShot(sound);
        }


    }

    public void SetVolume(Slider slider)
    {
            PlayerPrefs.SetFloat("volume", slider.value); 
            PlayerPrefs.Save();
        instance.backgroundAudioSrc.volume = slider.value;
    }

    private float GetVolume()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1f);
            PlayerPrefs.Save();
        }

        instance.backgroundAudioSrc.volume = PlayerPrefs.GetFloat("volume");

        Debug.Log(PlayerPrefs.GetFloat("volume"));
        return PlayerPrefs.GetFloat("volume");

    }
}