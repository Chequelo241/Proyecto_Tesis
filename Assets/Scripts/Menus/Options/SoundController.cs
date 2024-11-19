using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class SoundController: MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public Slider volumeSlider;


    void Start()
    {
        // Cargar el valor del volumen al inicio
        if (PlayerPrefs.HasKey("Volumen"))
        {
            float volume = PlayerPrefs.GetFloat("Volumen");
            audioMixer.SetFloat("Volumen", volume);
            volumeSlider.value = volume;
        }
        else 
        {
            float defaultVolume = 0f;
            audioMixer.SetFloat("Volumen", defaultVolume); 
            volumeSlider.value = defaultVolume;
        }
    }

    public void AudioChange(float vol) {
        audioMixer.SetFloat("Volumen", vol);
        volumeSlider.value = vol;
        // Guardar el valor del volumen
        PlayerPrefs.SetFloat("Volumen", vol);
    }

}
