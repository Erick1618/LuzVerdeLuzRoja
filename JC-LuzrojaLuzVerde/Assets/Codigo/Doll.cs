
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Doll : MonoBehaviour
{
    public Transform cabeza;
    public Transform cuerpo;
    int tiempo;
    private Reloj inicio;
    public AudioSource instrucciones1;
    public AudioSource instrucciones2;
    [Tooltip("Disparo")]
    public AudioSource death;
    public AudioSource[] luz;
    public AudioSource[] doll;
    float timerinicial=0f;
    bool muerto = false;
    private bool cantando = false;
   
    public Collider area;
    private bool volteada = false;
   
    public int min;
    private LogicaPersonaje1 posicion;
    private bool start = true;
    public bool pausado = false;
    public bool pausadoaudio = false;
    public GameObject canvasInstrucciones;

    // Canvas de muerte
    public Colision primerTrigger;
    public GameObject canvasMuerte;
    public GameObject puntaje;
    public Text textoPuntaje;
    int valorItems = 100000;
    private Pausa cursor;

    public bool Volteada { get => volteada; set => volteada = value; }

    // Start is called before the first frame update
    void Start()
    {
       
        inicio = FindObjectOfType<Reloj>();
        posicion = FindObjectOfType<LogicaPersonaje1>();
        cursor = FindObjectOfType<Pausa>();
        instrucciones1.Play();
        instrucciones2.PlayDelayed(10);
        doll[1].PlayDelayed(10);
        canvasInstrucciones.SetActive(true);

        area.isTrigger = false;

        canvasMuerte.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        inicio_Audio();
        if (!start) 
        {
            if (!pausado)
            {

                area.isTrigger = true;
                muneca_Voltea();
            }
            else
            {
                luz[min].Stop();

            }
            canvasInstrucciones.SetActive(false);
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
           
            switch (inicio.Minutos) 
            {
                case 0: luz[0].Play(); min = 0; break;
                case 1: luz[1].Play(); min = 1; break;
                case 2: luz[1].Play(); min = 1; break;
                case 3: luz[2].Play(); min = 2; break;
                case 4: luz[3].Play(); min = 3; break;
                case 5: luz[3].Play(); min = 3; break;
            }
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
                        tiempo_Scaneo();

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
        timerinicial += Time.deltaTime * 1;
        tiempo = (int)timerinicial % 60;


        if (tiempo == 4)
        {

            timerinicial = 0;
            volteada = false;
            doll[1].Play();
            cantando = false;


        }
        verifica_movimiento();

    }
    public void verifica_movimiento() 
    {
        if (posicion.estadendro)
        {
            if (posicion.X != 0 || posicion.Y != 0)
            {
                cursor.Cursordisable(true);

                if (!death.isPlaying)
                {
                    death.Play();
                    
                    // Mostrar canvas muerte, ocultar canvas puntaje 0/10
                    puntaje.SetActive(false);
                    canvasMuerte.gameObject.SetActive(true);
                    cursor.time_one();
                    // Almacenar el puntaje es PlayerPrefs
                    PlayerPrefs.SetInt("PuntajeItems", primerTrigger.puntaje * valorItems);
                    PlayerPrefs.SetInt("PuntajeFinal", primerTrigger.puntaje * valorItems);

                    // Puntajes
                    textoPuntaje.text = "$ " + PlayerPrefs.GetInt("PuntajeFinal");

                    // Creando record
                    if (PlayerPrefs.GetInt("PuntajeFinal") > PlayerPrefs.GetInt("Record5"))
                    {

                        if (PlayerPrefs.GetInt("PuntajeFinal") > PlayerPrefs.GetInt("Record4"))
                        {

                            if (PlayerPrefs.GetInt("PuntajeFinal") > PlayerPrefs.GetInt("Record3"))
                            {

                                if (PlayerPrefs.GetInt("PuntajeFinal") > PlayerPrefs.GetInt("Record2"))
                                {

                                    if (PlayerPrefs.GetInt("PuntajeFinal") > PlayerPrefs.GetInt("Record1"))
                                    {

                                        PlayerPrefs.SetInt("Record2", PlayerPrefs.GetInt("Record1"));
                                        PlayerPrefs.SetInt("Record3", PlayerPrefs.GetInt("Record2"));
                                        PlayerPrefs.SetInt("Record4", PlayerPrefs.GetInt("Record3"));
                                        PlayerPrefs.SetInt("Record5", PlayerPrefs.GetInt("Record4"));
                                        PlayerPrefs.SetInt("Record1", PlayerPrefs.GetInt("PuntajeFinal"));
                                    }

                                    else
                                    {
                                        PlayerPrefs.SetInt("Record5", PlayerPrefs.GetInt("Record4"));
                                        PlayerPrefs.SetInt("Record4", PlayerPrefs.GetInt("Record3"));
                                        PlayerPrefs.SetInt("Record3", PlayerPrefs.GetInt("Record2"));
                                        PlayerPrefs.SetInt("Record2", PlayerPrefs.GetInt("PuntajeFinal"));
                                    }
                                }

                                else
                                {
                                    PlayerPrefs.SetInt("Record5", PlayerPrefs.GetInt("Record4"));
                                    PlayerPrefs.SetInt("Record4", PlayerPrefs.GetInt("Record3"));
                                    PlayerPrefs.SetInt("Record3", PlayerPrefs.GetInt("PuntajeFinal"));

                                }
                            }

                            else
                            {
                                PlayerPrefs.SetInt("Record5", PlayerPrefs.GetInt("Record4"));
                                PlayerPrefs.SetInt("Record4", PlayerPrefs.GetInt("PuntajeFinal"));
                            }
                        }

                        else
                        {
                            PlayerPrefs.SetInt("Record5", PlayerPrefs.GetInt("PuntajeFinal"));
                        }
                    }

                    // Guardar todo
                    PlayerPrefs.Save();
                    pausado = true;

                }

            }
        }
    }


    public void rotation_Doll(Transform obj, int grados) 
    {
       // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, grados, transform.rotation.eulerAngles.z)), Time.deltaTime * 3);
       obj.rotation = Quaternion.Slerp(obj.rotation, Quaternion.Euler(new Vector3(obj.rotation.eulerAngles.x, grados, obj.rotation.eulerAngles.z)), Time.deltaTime * 3);
    }
}
