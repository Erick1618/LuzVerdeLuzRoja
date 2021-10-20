
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
    private bool start = true;
    // Start is called before the first frame update
    void Start()
    {
        
        inicio = FindObjectOfType<Reloj>();
        instrucciones1.Play(1);
        rotation_Doll(cuerpo, 180);
        rotation_Doll(cabeza, 180);

    }

    // Update is called once per frame
    void Update()
    {
        inicio_Audio();

        //if (inicio.Seg >= 30) 
        //{
        //   rotation_Doll(cabeza,180);
        //}
        //if (inicio.Seg <= 30)
        //{
        //    rotation_Doll(cabeza,0);
        //}
    }

    public void inicio_Audio() 
    {
        //booleano para iniciar solo una ves las instrucciones
        if (start) {

            if (instrucciones1.isPlaying)
            {
                instrucciones2.PlayDelayed(1);
                
                doll[1].PlayDelayed(1);
                
            }

            if (!instrucciones2.isPlaying && !instrucciones1.isPlaying)
            {
                inicio.start = true;
                start = false;

            }
            if (instrucciones2.isPlaying)
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
    public void rotation_Doll(Transform obj,int grados) 
    {
       // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, grados, transform.rotation.eulerAngles.z)), Time.deltaTime * 3);
       obj.rotation = Quaternion.Slerp(obj.rotation, Quaternion.Euler(new Vector3(obj.rotation.eulerAngles.x, grados, obj.rotation.eulerAngles.z)), Time.deltaTime * 3);
    }
}
