
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
    float timerinicial=0f;

    private bool cantando = false;
    private System.Random scanplayer;
    public Collider area;
    private bool volteada = false;
    private int valor;
    private int min;

    private bool start = true;

    public bool Volteada { get => volteada; set => volteada = value; }

    // Start is called before the first frame update
    void Start()
    {
        var seed = Environment.TickCount;
        scanplayer = new System.Random(seed);
        valor = scanplayer.Next(2, 4);
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
            area.enabled=false;
            area.isTrigger = true;
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
            min = inicio.Minutos - 1;
            if (min<0) 
            {
                min = 0;
            }
            luz[min].Play();
            cantando = true; 
        }
        else if (cantando)
        {
            if (inicio.Minutos == 4)
            {

                if (!luz[min].isPlaying)
                {
                    if (!volteada)
                    {
                        doll[0].Play();
                        volteada = true;
                    }
                    if (volteada) 
                    {
                        tiempo_Scaneo();
                    }
                    
                }
                
            }
            if (inicio.Minutos == 3)
            {

                if (!luz[min].isPlaying)
                {
                    if (!volteada)
                    {
                        doll[0].Play();
                        volteada = true;
                        tiempo_Scaneo();
                    }
                    if (volteada)
                    {
                        tiempo_Scaneo();
                    }
                }
            }
            if (inicio.Minutos == 2)
            {

                if (!luz[min].isPlaying)
                {
                    if (!volteada)
                    {
                        doll[0].Play();
                        volteada = true;
                        tiempo_Scaneo();
                    }
                    if (volteada)
                    {
                        tiempo_Scaneo();
                    }
                }
            }
            if (inicio.Minutos == 1)
            {

                if (!luz[min].isPlaying)
                {
                    if (!volteada)
                    {
                        doll[0].Play();
                        volteada = true;
                        tiempo_Scaneo();
                    }
                    if (volteada)
                    {
                        tiempo_Scaneo();
                    }
                }
            }
            if (inicio.Minutos == 0)
            {

                if (!luz[min].isPlaying)
                {
                    if (!volteada)
                    {
                        doll[0].Play();
                        volteada = true;
                        tiempo_Scaneo();
                    }
                    if (volteada)
                    {
                        tiempo_Scaneo();
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

    public void tiempo_Scaneo()
    {
       timerinicial += Time.deltaTime*1;
        tiempo = (int)timerinicial % 60;
        //print(tiempo);

        if (tiempo==valor) 
        {

            timerinicial = 0;
            volteada = false;
            doll[1].Play();
            cantando = false;
            valor = scanplayer.Next(2, 4);
        }
    }
    public void rotation_Doll(Transform obj, int grados) 
    {
       // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, grados, transform.rotation.eulerAngles.z)), Time.deltaTime * 3);
       obj.rotation = Quaternion.Slerp(obj.rotation, Quaternion.Euler(new Vector3(obj.rotation.eulerAngles.x, grados, obj.rotation.eulerAngles.z)), Time.deltaTime * 3);
    }
}
