using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resoluciones : MonoBehaviour
{
    public float aspect;
    public float rounded;
    UnityEngine.UI.CanvasScaler cv;
    public Camera cam;
    void Start()
    {
        cv = this.GetComponent<UnityEngine.UI.CanvasScaler>();
        update_resolucion();
    }

    void update_resolucion() 
    {
        aspect = cam.aspect;

        rounded = (int)(aspect * 100.0f) / 100.0f;


        if (rounded == 1.65f || rounded == 1.66f || rounded == 1.57f)
            Addration(0, 5.34f);
        else if (rounded == 2.04f || rounded == 2.05f || rounded == 2.06f)
            Addration(0.88f, 4.86f);
        else if (rounded == 1.70f || rounded == 1.71f || rounded == 1.69f)
            Addration(0, 5.21f);
        else if (rounded == 1.33f || rounded == 1.32f || rounded == 1.34f)
            Addration(0, 6.77f);
        else
            Addration(0,5);
    }
    void Addration(float m, float sz) 
    {
        if (cv != null) cv.matchWidthOrHeight = m;
        cam.orthographicSize = sz;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y)) update_resolucion();
    }
}
