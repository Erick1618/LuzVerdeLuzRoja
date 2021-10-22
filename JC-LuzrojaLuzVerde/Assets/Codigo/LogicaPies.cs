using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPies : MonoBehaviour
{
    public LogicaPersonaje1 logicaP1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider obj)
    {
        if (obj.tag == "Muro")
        {
            logicaP1.puedoSaltar = false;
        }
        else
        {
            if(obj.tag == "AM")
            {
                logicaP1.puedoSaltar = false;
            }
            logicaP1.puedoSaltar = true;
        }

    }

    private void OnTriggerExit(Collider obj)
    {
        logicaP1.puedoSaltar = false;
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Terreno")
        {
            logicaP1.puedoSaltar = true;
        }
    }
}
