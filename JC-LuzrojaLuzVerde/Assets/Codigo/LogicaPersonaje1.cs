using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPersonaje1 : MonoBehaviour
{
    public float velocidadInicial = 5.0f;
    public float velocidadMov;
    public int velocidadCorrer = 10;
    public float velocidadRot = 200.0f;

    private Animator anim;
    public float x, y; // Saber si nuestro personaje se está moviendo

    public Rigidbody rb;
    public float fuerzaDeSalto = 12f;
    public bool puedoSaltar;

    // Start is called before the first frame update
    void Start()
    {
        puedoSaltar = false;
        velocidadMov = velocidadInicial;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * velocidadRot, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMov);
    }
    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        if(puedoSaltar)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("brinque", true);
                rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);
            }
            anim.SetBool("tocoSuelo", true);
        }
        else
        {
            EstoyCayendo();
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            if(puedoSaltar) // Estoy en el piso
            {
                velocidadMov = velocidadCorrer;
                if(y > 0)
                {
                    // Entonces estamos avanzando
                    anim.SetBool("corriendo", true);
                }
                else
                {
                    anim.SetBool("corriendo", false);
                }
            }
            else
            {
                anim.SetBool("corriendo", false);
                if (puedoSaltar)
                {
                    velocidadMov = velocidadInicial;
                }
            }
        }
        else
        {
            anim.SetBool("corriendo", false);
            if(puedoSaltar)
            {
                velocidadMov = velocidadInicial;
            }
        }
    }

    public void EstoyCayendo()
    {
        anim.SetBool("tocoSuelo", false);
        anim.SetBool("brinque", false);
    }
}
