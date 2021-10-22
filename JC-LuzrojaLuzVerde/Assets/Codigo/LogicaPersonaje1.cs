using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPersonaje1 : MonoBehaviour
{
    public float velocidadMov = 5.0f;
    public float velocidadRot = 200.0f;
    private Animator anim;
    private float y; // Saber si nuestro personaje se está moviendo
    private float x;
    public AudioSource death;
    private Doll muneca;

    public float X { get => x; set => x = value; }
    public float Y { get => y; set => y = value; }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        muneca = FindObjectOfType<Doll>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velocidadRot, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMov);

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "AreaMuerte")
        {
            if (muneca.Volteada)
            {
                if (x != 0 || y != 0)
                {
                    personaje_Death();
                }

            }

        }

        if (other.tag == "Final") {
            velocidadMov = 0;
            velocidadRot = 0;
        }


    }
    public void personaje_Death()
    {

        death.Play(1);
    }

}
