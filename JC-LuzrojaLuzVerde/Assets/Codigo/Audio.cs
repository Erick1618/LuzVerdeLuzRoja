using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioClip[] audios;
    private AudioSource controlAudio;
    private AudioSource temp;

    private void Awake()
    {
        controlAudio = GetComponent<AudioSource>();
    }

    public void Seleccion_Audio(int indice) 
    {
        controlAudio.PlayOneShot(audios[indice]);
    }

    public void IsPlaying(int i) 
    {
       
    }
}
