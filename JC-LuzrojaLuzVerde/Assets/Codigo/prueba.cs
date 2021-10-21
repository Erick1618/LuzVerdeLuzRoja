using UnityEngine;

public class prueba : MonoBehaviour
{
    public float velocidadMov = 5.0f;
    public float velocidadRot = 200.0f;
    public float x, y; // Saber si nuestro personaje se está moviendo
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velocidadRot, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMov);

    }
}