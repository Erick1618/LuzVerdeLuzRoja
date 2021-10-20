using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class Reloj : MonoBehaviour
{
    [Tooltip("Tiempo Inicial en segundos")]
    public int tiempoInicial;
    [Tooltip("Escala del tiempo del reloj")]
    public float escalaDeTiempo = 1;
    public TextMeshPro TextCont;

    // Start is called before the first frame update
    void Start()
    {
        TextCont = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        TextCont.text = "hola";
    }
}
