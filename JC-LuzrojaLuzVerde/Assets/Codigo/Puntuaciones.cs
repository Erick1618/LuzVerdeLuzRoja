using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntuaciones : MonoBehaviour
{
    public Text Record1;
    public Text Record2;
    public Text Record3;
    public Text Record4;
    public Text Record5;

    private void Start() {
        Record1.text = "$ " + PlayerPrefs.GetInt("Record1", 0).ToString();
        Record2.text = "$ " + PlayerPrefs.GetInt("Record2", 0).ToString();
        Record3.text = "$ " + PlayerPrefs.GetInt("Record3", 0).ToString();
        Record4.text = "$ " + PlayerPrefs.GetInt("Record4", 0).ToString();
        Record5.text = "$ " + PlayerPrefs.GetInt("Record5", 0).ToString();
    }

}
