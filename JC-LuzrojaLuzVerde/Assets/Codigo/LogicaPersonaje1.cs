using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaPersonaje1 : MonoBehaviour
{
    public float velocidadMov = 5.0f;
    public float velocidadRot = 200.0f;
    private Animator anim;
    private float y; // Saber si nuestro personaje se está moviendo
    private float x;
    
    private Doll muneca;
    private Vector3 posicioninicial;
    public bool estadendro = false;
    private Quaternion xsd;
    public Transform persona;

    public float Y { get => y; set => y = value; }
    public float X { get => x; set => x = value; }


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
   
  
}
