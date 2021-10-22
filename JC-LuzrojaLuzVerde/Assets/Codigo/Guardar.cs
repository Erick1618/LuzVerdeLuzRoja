using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Guardar : MonoBehaviour
{
    public Colision primerTrigger;
    public GameObject pantallaPuntaje;
    public Text textoPuntaje;
    public Text textoRecord;
    private Reloj segundos;

    int valorItems = 100000;
    int valorTiempo = 1000;

    void Start() {
        pantallaPuntaje.gameObject.SetActive(false);
        segundos = FindObjectOfType<Reloj>();

        textoRecord.text = PlayerPrefs.GetInt("Record").ToString();
    }

    private void OnTriggerEnter(Collider obj) {
        if (obj.tag == "Final") {
            // Guardado de puntajes en PlayerPrefs
            PlayerPrefs.SetInt("PuntajeItems", primerTrigger.puntaje * valorItems);
            PlayerPrefs.SetInt("PuntajeTiempo", ((segundos.Minutos * 60) + (segundos.Seg)) * valorTiempo);
            PlayerPrefs.SetInt("PuntajeFinal", (primerTrigger.puntaje * valorItems) + (((segundos.Minutos * 60) + (segundos.Seg))) * valorTiempo);

            // Creando record
            if (PlayerPrefs.GetInt("PuntajeFinal") > PlayerPrefs.GetInt("Record")) {
                PlayerPrefs.SetInt("Record", PlayerPrefs.GetInt("PuntajeFinal"));
            }

            // Prueba de almacenamiento de puntaje con consola
            Debug.Log("Puntaje en items: " + PlayerPrefs.GetInt("PuntajeItems"));
            Debug.Log("Puntaje en tiempo: " + PlayerPrefs.GetInt("PuntajeTiempo"));
            Debug.Log("Puntaje final: " + PlayerPrefs.GetInt("PuntajeFinal"));

            // Mostrar canvas cuando pase por el trigger
            pantallaPuntaje.gameObject.SetActive(true);

            // Puntajes
            textoPuntaje.text = "$ " + PlayerPrefs.GetInt("PuntajeFinal");
            textoRecord.text = "$ " + PlayerPrefs.GetInt("Record");
        }
    }
}
