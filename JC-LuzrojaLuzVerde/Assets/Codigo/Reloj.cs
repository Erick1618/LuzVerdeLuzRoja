using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;
using System;

public class Reloj : MonoBehaviour
{
    [Tooltip("Tiempo Inicial en segundos")]
    public int tiempoInicial;
    [Tooltip("Escala del tiempo del reloj")]
    public float escalaDeTiempo = 1;

    public bool start = false;
    private TextMeshPro TextCont;
   
    private float tiempoFrame = 0f;
    private float tiempoSegundos = 0f;
    private float tiempoALpausar, escalaTiempoInicial;
    private bool pausado = false;
    private int seg;
    private int minutos;

    public int Seg { get => seg; set => seg = value; }
    public int Minutos { get => minutos; set => minutos = value; }

    // Start is called before the first frame update
    void Start()
    {
        escalaTiempoInicial = escalaDeTiempo;
        TextCont = GetComponent<TextMeshPro>();
       
        tiempoSegundos = tiempoInicial;
        actualiza_Reloj(tiempoInicial);
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

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pausa();
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
            print(Seg);
        }
    }


}
