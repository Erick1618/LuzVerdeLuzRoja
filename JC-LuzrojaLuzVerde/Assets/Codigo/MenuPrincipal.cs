using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public AudioSource audioF;
    // Start is called before the first frame update
    void Start()
    {
        audioF.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EmpezarJuego(string pNombre)
    {
        SceneManager.LoadScene(pNombre);
    }

    public void CerrarJuego()
    {
        Application.Quit();
        
    }
}
