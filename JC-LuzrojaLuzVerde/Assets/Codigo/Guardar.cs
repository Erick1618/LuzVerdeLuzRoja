using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Guardar : MonoBehaviour
{
    public Colision primerTrigger;
    public GameObject pantallaPuntaje;
    public GameObject puntaje;
    public Text textoPuntaje;
    private Reloj segundos;
    private Reloj reloj;
    int valorItems = 100000;
    int valorTiempo = 10000;
    private Pausa cursor;
    private Doll doll;

    void Start() {
        pantallaPuntaje.gameObject.SetActive(false);
        reloj = FindObjectOfType<Reloj>();
        segundos = FindObjectOfType<Reloj>();
        cursor = FindObjectOfType<Pausa>();
        doll = FindObjectOfType<Doll>();
    }

    private void OnTriggerEnter(Collider obj) {
        if (obj.tag == "Final") {
            reloj.llego = true;
            // Borrar contador de puntos
            puntaje.SetActive(false);
            Time.timeScale = 0;
            doll.pausado = true;
            cursor.Cursordisable(true);
            // Guardado de puntajes en PlayerPrefs
            PlayerPrefs.SetInt("PuntajeItems", primerTrigger.puntaje * valorItems);
            PlayerPrefs.SetInt("PuntajeTiempo", ((segundos.Minutos * 60) + (segundos.Seg)) * valorTiempo);
            PlayerPrefs.SetInt("PuntajeFinal", (primerTrigger.puntaje * valorItems) + (((segundos.Minutos * 60) + (segundos.Seg))) * valorTiempo);


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

            // Prueba de almacenamiento de puntaje con consola
            Debug.Log("Puntaje en items: " + PlayerPrefs.GetInt("PuntajeItems"));
            Debug.Log("Puntaje en tiempo: " + PlayerPrefs.GetInt("PuntajeTiempo"));
            Debug.Log("Puntaje final: " + PlayerPrefs.GetInt("PuntajeFinal"));

            // Mostrar canvas cuando pase por el trigger
            pantallaPuntaje.gameObject.SetActive(true);

            // Puntajes
            textoPuntaje.text = "$ " + PlayerPrefs.GetInt("PuntajeFinal");

            // Guardar todo
            PlayerPrefs.Save();

            // Cancelar movimiento y silenciar a la mu?eca

        }
    }
}
