
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Doll : MonoBehaviour
{
    //public Transform cabeza;

    private bool voltea = false;
    public TextMeshPro minutos;
    public TextMeshPro segundos;
    public Transform cabeza;
    int tiempo;
    private Reloj inicio;
    public AudioSource instrucciones1;
    public AudioSource instrucciones2;
    public AudioSource[] luz;
    private bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        
        inicio = FindObjectOfType<Reloj>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (instrucciones1.isPlaying)
        {
            instrucciones2.PlayDelayed(1);
        }
        if (!instrucciones2.isPlaying && !instrucciones1.isPlaying)
        {
            inicio.start = true;
           
        }
        //tiempo = Convert.ToInt32(segundos.text);
        if (inicio.Seg >= 30) 
        {
            cabeza_Doll(180);
        }
        if (inicio.Seg <= 30)
        {
            cabeza_Doll(0);
        }
    }
    public void inicio_Audio() 
    {
        if (!start)
        {
            if (!instrucciones1.isPlaying)
            {
               
                instrucciones2.Play(1);
            }
            else if (!instrucciones2.isPlaying)
            {
                inicio.start = true;
                start = true;
            }
        }
    }
    public void cabeza_Doll(int grados) 
    {
       // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, grados, transform.rotation.eulerAngles.z)), Time.deltaTime * 3);
       cabeza.rotation = Quaternion.Slerp(cabeza.rotation, Quaternion.Euler(new Vector3(cabeza.rotation.eulerAngles.x, grados, cabeza.rotation.eulerAngles.z)), Time.deltaTime * 3);
    }
}
