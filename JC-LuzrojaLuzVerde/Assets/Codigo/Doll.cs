
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class Doll : MonoBehaviour
{
   
    
    public Transform cabeza;
    public Transform cuerpo;
    int tiempo;
    private Reloj inicio;
    public AudioSource instrucciones1;
    public AudioSource instrucciones2;
    public AudioSource[] luz;
    public AudioSource[] doll;
    float timerCabeza;

    private bool cantando = false;
    private System.Random scanplayer;

    private bool volteada = false;



    private bool start = true;
    // Start is called before the first frame update
    void Start()
    {
        var seed = Environment.TickCount;
        scanplayer = new System.Random(seed);
        inicio = FindObjectOfType<Reloj>();
        instrucciones1.Play();
        instrucciones2.PlayDelayed(10);
        doll[1].PlayDelayed(10);
        

    }

    // Update is called once per frame
    void Update()
    {
        inicio_Audio();
        if (!start) 
        {
            muneca_Voltea();



        }
        


    }

    public void inicio_Audio() 
    {
        //booleano para iniciar solo una ves las instrucciones
        if (start) {

           

            if (!instrucciones2.isPlaying && !instrucciones1.isPlaying)
            {
                
                inicio.start = true;
                start = false;

            }
            if (instrucciones1.isPlaying)
            {
                rotation_Doll(cuerpo, 180);
                rotation_Doll(cabeza, 180);
            }
            else 
            {
                rotation_Doll(cuerpo, 0);
                rotation_Doll(cabeza, 0);
            }
        }
    }
    public void muneca_Voltea() 
    {
        if (!cantando)
        {
            luz[inicio.Minutos].Play();
            cantando = true; 
        }
        else if (cantando)
        {
            if (inicio.Minutos == 4)
            {

                if (!luz[inicio.Minutos].isPlaying)
                {
                    if (!volteada)
                    {
                        doll[0].Play();
                        volteada = true;
                    }
                }
            }
            if (inicio.Minutos == 3)
            {

                if (!luz[inicio.Minutos].isPlaying)
                {
                    if (!volteada)
                    {
                        doll[0].Play();
                        volteada = true;
                    }
                   
                }
            }

            if (volteada)
            {
                rotation_Doll(cabeza, 180);
            }
            else
            {
                rotation_Doll(cabeza, 0);
            }

        }
        
    }
    public void rotation_Doll(Transform obj, int grados) 
    {
       // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, grados, transform.rotation.eulerAngles.z)), Time.deltaTime * 3);
       obj.rotation = Quaternion.Slerp(obj.rotation, Quaternion.Euler(new Vector3(obj.rotation.eulerAngles.x, grados, obj.rotation.eulerAngles.z)), Time.deltaTime * 3);
    }
}
