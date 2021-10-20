using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class Reloj : MonoBehaviour
{
    [Tooltip("Tiempo Inicial en segundos")]
    public int tiempoInicial;
    [Tooltip("Escala del tiempo del reloj")]
    public float escalaDeTiempo = 1;
    public TextMesh TextCont;

    // Start is called before the first frame update
    void Start()
    {
        TextCont = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
