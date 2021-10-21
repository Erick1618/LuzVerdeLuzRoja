using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaMuerte : MonoBehaviour
{

    private Doll muneca;
    private LogicaPersonaje1 personaje;
    public AudioSource death;

    // Start is called before the first frame update
    void Start()
    {
        muneca = FindObjectOfType<Doll>();
        personaje = FindObjectOfType<LogicaPersonaje1>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "personaje")
        {
            if (muneca.Volteada)
            {
                if (personaje.X != 0 || personaje.Y != 0)
                {
                    personaje_Death();
                }

            }
            print("estoy dentro personaje");
        }
        print("estoy dentro");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "personaje")
        {
            
            print("entre personaje");
        }
        print("entre");
    }

    public void personaje_Death()
    {

        death.Play(1);
    }
}
