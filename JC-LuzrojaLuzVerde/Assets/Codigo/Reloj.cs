using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;
using System;
using UnityEngine.UI;

public class Reloj : MonoBehaviour
{
    [Tooltip("Tiempo Inicial en segundos")]
    public int tiempoInicial;
    [Tooltip("Escala del tiempo del reloj")]
    public float escalaDeTiempo = 1;
    private Doll doll;
    public bool start = false;
    private TextMeshPro TextCont;
   
    private float tiempoFrame = 0f;
    private float tiempoSegundos = 0f;
    private float tiempoALpausar, escalaTiempoInicial;
    private bool pausado = false;
    private int seg;
    private int minutos;
    public bool llego = false;
    public int Seg { get => seg; set => seg = value; }
    public int Minutos { get => minutos; set => minutos = value; }
    // Canvas de muerte
    public Colision primerTrigger;
    public GameObject canvasMuerte;
    public GameObject puntaje;
    public Text textoPuntaje;
    int valorItems = 100000;
    private Pausa cursor;
    // Start is called before the first frame update
    void Start()
    {
        escalaTiempoInicial = escalaDeTiempo;
        TextCont = GetComponent<TextMeshPro>();
        cursor = FindObjectOfType<Pausa>();
        tiempoSegundos = tiempoInicial;
        actualiza_Reloj(tiempoInicial);
        doll = FindObjectOfType<Doll>();
    }

    // Update is called once per frame
    void Update()
    {
        //saber cuanto dura cada frame
        if (start)
        {
            tiempoFrame = Time.deltaTime * escalaDeTiempo;
            tiempoSegundos -= tiempoFrame;

            actualiza_Reloj(tiempoSegundos);
            if (!llego) 
            {
                time_Out();
            }
            
        }
    }

    public void pausa() 
    {
       if (!pausado)
        {
            pausado = true;
            tiempoALpausar = escalaDeTiempo;
            escalaDeTiempo = 0;

        }
        else
        {
            pausado = false;
            escalaDeTiempo = tiempoALpausar;
        }
        
    }
    public void actualiza_Reloj(float segundos) 
    {
        Minutos = 0;
        Seg = 0;
        string textReloj;
        if (segundos < 0)
        {
            segundos = 0;
        }
        else 
        {
            Minutos = (int)segundos / 60;
            Seg = (int)segundos % 60;
            textReloj = Minutos.ToString("00") + ":" + Seg.ToString("00");
           
            TextCont.text = textReloj;
            //print(Seg);
        }
    }
    public void time_Out()
    {
        if (Minutos == 0 && Seg == 0)
        {
            doll.death.Play();
            Time.timeScale = 0;
            doll.pausado = true;
            // Mostrar canvas muerte, ocultar canvas puntaje 0/10
            puntaje.SetActive(false);
            canvasMuerte.gameObject.SetActive(true);
            cursor.Cursordisable(true);
            // Almacenar el puntaje es PlayerPrefs
            PlayerPrefs.SetInt("PuntajeItems", primerTrigger.puntaje * valorItems);
            PlayerPrefs.SetInt("PuntajeFinal", primerTrigger.puntaje * valorItems);

            // Puntajes
            textoPuntaje.text = "$ " + PlayerPrefs.GetInt("PuntajeFinal");

            // Guardar todo
            PlayerPrefs.Save();
        }
    }


}
