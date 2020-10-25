using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProximaFase : MonoBehaviour
{
    // Start is called before the first frame update
    public Image frase1;
    public Image frase2;
    public Image frase3;
    public Image frase4;
    public Image frase5;
    public Image frase6;
    public Image frase7;
    public Image frase8;

    public GameObject Proximo;
    void Start()
    {
        Proximo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (frase1.color == Color.green &&
            frase2.color == Color.green &&
            frase3.color == Color.green &&
            frase4.color == Color.green &&
            frase5.color == Color.green &&
            frase6.color == Color.green &&
            frase7.color == Color.green &&
            frase8.color == Color.green)
        {
            Proximo.SetActive(true);
        }
    }
}
