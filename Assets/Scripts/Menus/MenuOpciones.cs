using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class MenuOpciones : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    void Start()
    {
        // Cargar el valor del volumen al inicio
        if (PlayerPrefs.HasKey("Volumen"))
        {
            float volume = PlayerPrefs.GetFloat("Volumen");
            audioMixer.SetFloat("Volumen", volume);
        }
    }
    public void FullScreen(bool fullScreen) {
        Screen.fullScreen = fullScreen;
    }
    
    public void AudioChange(float vol) {
        audioMixer.SetFloat("Volumen", vol);
        // Guardar el valor del volumen
        PlayerPrefs.SetFloat("Volumen", vol);
    }
}
