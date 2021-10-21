using UnityEngine;
using UnityEngine.UI;

public class Colision : MonoBehaviour {
    public Text scoreText;
    public AudioSource beep;

    int puntaje = 0;

    void Start() {
        scoreText.text = puntaje + " / 10";
    }

    void Update() { 
        scoreText.text = puntaje + " / 10";
    }

    private void OnTriggerEnter(Collider obj) {
        if (obj.tag == "Item") {
            puntaje++;
            beep.Play();
            Destroy(obj.gameObject);
        }
    }
}