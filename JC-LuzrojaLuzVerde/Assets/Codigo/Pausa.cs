using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Pausa : MonoBehaviour
{
    public Slider slider;
    private float slidervalue;
    public Toggle toggle;
    
    public TMP_Dropdown calidaImg;
   private int calida;
         
    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else 
        {
            toggle.isOn = false;
        }
        calida = PlayerPrefs.GetInt("calidad",3);
        calidaImg.value = calida;
        calidad_Imagen();
        slider.value = PlayerPrefs.GetFloat("volumen");
        AudioListener.volume = slider.value;
    }
    public void valor_volumen(float vol) 
    {
        slidervalue = vol;
        PlayerPrefs.SetFloat("volumen",slidervalue);
        AudioListener.volume = slider.value;
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
   
}
