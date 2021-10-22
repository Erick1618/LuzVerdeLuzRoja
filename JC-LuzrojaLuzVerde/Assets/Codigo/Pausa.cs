using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public Slider slider;
    private float slidervalue;

    public Slider sliderBrillo;
    public Image panelbrillo;
    private float slidervaluebrillo;

    public Toggle toggle;
    public Toggle postProccesing;
    public GameObject postProceso;

    public TMP_Dropdown calidaImg;
    public TMP_Dropdown resolucionDP;
    private int calida;
    Resolution[] resoluciones;

    private Reloj reloj;
  
    private Doll doll;
    string temp1;
   
    private bool cursor=true;
    public GameObject pausePrincipal;
    public GameObject pauseopciones;
    void Start()
    {
        reloj = FindObjectOfType<Reloj>();
        
        doll = FindObjectOfType<Doll>();
        //fullscreen
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else 
        {
            toggle.isOn = false;
        }
        //brillo
        sliderBrillo.value = PlayerPrefs.GetFloat("brillo");
        panelbrillo.color = new Color(panelbrillo.color.r, panelbrillo.color.g, panelbrillo.color.b, sliderBrillo.value);
        //post procesado
        temp1=PlayerPrefs.GetString("Procesado");
        postProceso.SetActive(post_Procesado_verifica(temp1));
        //Resolucin
        vaerifica_resolucion();
        //calidad imagen
        calida = PlayerPrefs.GetInt("calidad",3);
        calidaImg.value = calida;
        calidad_Imagen();
        slider.value = PlayerPrefs.GetFloat("volumen");
        AudioListener.volume = slider.value;

        
    }
    private void Update()
    {
 
        pause_Game();

        if (!cursor) {
            Cursor_visible(cursor);
            
        }
        
    }
    private void Cursor_visible(bool xd) 
    {
        
    }
    public void Cursordisable(bool xd)
    {
        cursor= xd;
    }

    private bool post_Procesado_verifica(string xd)
    {
        if (xd == "true")
        {
            return true;
        }
        else 
        {
            return false;
        }
        
    }
    public void post_Procesado(bool xsd)
    {
        
        postProceso.SetActive(xsd);
       
        string temp;
        if (xsd)
        {
            temp = "true";
        }
        else 
        { 
            temp = "false"; 
        }
        PlayerPrefs.SetString("Procesado",temp);
    }

    public void valor_volumen(float vol) 
    {
        slidervalue = vol;
        PlayerPrefs.SetFloat("volumen",slidervalue);
        AudioListener.volume = slider.value;
    }
    public void slider_Brillo(float val) 
    {
        slidervaluebrillo = val;
        PlayerPrefs.SetFloat("brillo", slidervaluebrillo);
        panelbrillo.color = new Color(panelbrillo.color.r, panelbrillo.color.g, panelbrillo.color.b, sliderBrillo.value);

    }
    public void pantalla_Completa(bool fullScreen) 
    {
        Screen.fullScreen = fullScreen;
       
    }

    public void calidad_Imagen() 
    {
        QualitySettings.SetQualityLevel(calidaImg.value);
        PlayerPrefs.SetInt("calidad", calidaImg.value);
        calida = calidaImg.value;
    }
    public void vaerifica_resolucion() 
    {
        resoluciones = Screen.resolutions;
        resolucionDP.ClearOptions();
        List<string> opcionesR = new List<string>();
        List<string> res = new List<string>();

        int resActual = 0;

        for (int i = 0; i<resoluciones.Length;i++) 
        {
            string resop= resoluciones[i].width + " x " + resoluciones[i].height;
            opcionesR.Add(resop);

            if (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height) 
            {
                resActual = i;
            }
            

           
        }
      
        //res.Add(opcionesR[opcionesR.Count - 4]);
        //res.Add(opcionesR[opcionesR.Count - 2]);
        //res.Add(opcionesR[opcionesR.Count-1]);

        resolucionDP.AddOptions(opcionesR);
        resolucionDP.value = resActual;
        resolucionDP.RefreshShownValue();
        resolucionDP.value = PlayerPrefs.GetInt("resolucion", 0);
    }

    public void resolucion(int indiceRes) 
    {
        PlayerPrefs.SetInt("resolucion", resolucionDP.value);
        Resolution res = resoluciones[indiceRes];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void reanudar()
    {
        if (pausePrincipal.activeSelf)
        {
            Time.timeScale = 1;
            pausePrincipal.SetActive(false);
            doll.pausadoaudio = true;
            doll.pausado = false;
            //personaje.pausado = false;
            //reloj.pausado = true;
            //pausadoREc = false;
            cursor = false;
            Cursor_visible(cursor);

        }
        if (pauseopciones.activeSelf)
        {
            Time.timeScale = 1;
            pauseopciones.SetActive(false);
            doll.pausadoaudio = true;
            doll.pausado = false;
            //personaje.pausado = false;
            //reloj.pausado = true;
            //pausadoREc = false;
            cursor = false;
            Cursor_visible(cursor);
        }
    }
    public void pause_Game() 
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            cursor = true;
            Cursor_visible(cursor);
            if (!pausePrincipal.activeSelf && !pauseopciones.activeSelf)
            {
                pausePrincipal.SetActive(true);
            }


            if (reloj.start)
            {
                doll.pausado = true;
                //personaje.pausado = true;
                //if (!pausadoREc)
                //{
                //    reloj.pausado = true;
                //    pausadoREc = true;
                //}
            }
        }
       

        if (Input.GetKey(KeyCode.B))
        {
            
            if (pausePrincipal.activeSelf)
            {
                Time.timeScale = 1;
                pausePrincipal.SetActive(false);
                doll.pausadoaudio = true;
                doll.pausado = false;
                //personaje.pausado = false;
                //reloj.pausado = true;
                //pausadoREc = false;
                cursor = false;
                Cursor_visible(cursor);

            }
            if (pauseopciones.activeSelf)
            {
                Time.timeScale = 1;
                pauseopciones.SetActive(false);
                doll.pausadoaudio = true;
                doll.pausado = false;
                //personaje.pausado = false;
                //reloj.pausado = true;
                //pausadoREc = false;
                cursor = false;
                Cursor_visible(cursor);
            }


        }

    }
    public void menu_escena() 
    {
        SceneManager.LoadScene("Menu2.0");
        Time.timeScale = 1;
    }
    public void time_cero()
    {
        
        Time.timeScale = 1;
    }
    public void time_one()
    {

        Time.timeScale = 0;
    }
}
