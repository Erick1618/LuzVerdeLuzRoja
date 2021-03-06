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
    private float x;
    private float y; // Saber si nuestro personaje se est? moviendo

    public Rigidbody rb;
    public float fuerzaDeSalto = 12f;
    public bool puedoSaltar;
    public bool estadendro = false;
    public bool pausado = false;
    public float Y { get => y; set => y = value; }
    public float X { get => x; set => x = value; }

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

        if (puedoSaltar)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (anim.GetBool("tocoSuelo"))
                {
                    anim.SetBool("brinque", true);
                    rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    // Estoy en el piso
                    if (anim.GetBool("tocoSuelo"))
                    {
                        velocidadMov = velocidadCorrer;
                        if (y > 0)
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
                    velocidadMov = velocidadInicial;
                }
            }
            anim.SetBool("tocoSuelo", true);
        }
        else
        {
            EstoyCayendo();
            anim.SetBool("tocoSuelo", false);
        }

    }

    public void EstoyCayendo()
    {
        anim.SetBool("tocoSuelo", false);
        anim.SetBool("brinque", false);
    }
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "AM")
        {
            estadendro = true;
        }
        if (obj.tag == "Muro")
        {
            puedoSaltar = false;
        }

    }
    private void OnTriggerExit(Collider obj)
    {
        if (obj.tag == "AM")
        {
            estadendro = false;
        }

    }



}
