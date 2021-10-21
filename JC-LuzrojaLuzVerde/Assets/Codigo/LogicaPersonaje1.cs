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
    private Vector3 posicioninicial;
    public bool estadendro = false;
    private Quaternion xsd;
    public Transform persona;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        muneca = FindObjectOfType<Doll>();
        posicioninicial = new Vector3(206.3f, 10.2f, 10.9f);
        xsd = new Quaternion(0f,0f,0f,0f);
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

        if (estadendro)
        {
            
            print("hola");
            movimiento();
        }
    }
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "AM")
        {
            estadendro = true;
              
        }

    }
    private void OnTriggerExit(Collider obj)
    {
        if (obj.tag == "AM")
        {

            estadendro = false;
            
        }

    }
   
    public void movimiento() 
    {
        if (muneca.Volteada)
        {
            
            if (x != 0 || y != 0)
            {
                print("te moviste");
                if (!death.isPlaying)
                {
                    death.Play();
                  transform.SetPositionAndRotation(posicioninicial,xsd);
                }

            }
        }

    }
    public void personaje_Death()
    {
        

    }

}
