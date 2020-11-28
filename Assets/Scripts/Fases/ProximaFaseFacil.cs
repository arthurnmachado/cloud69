using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProximaFaseFacil: MonoBehaviour
{
    public Image frase1;
    public Image frase2;
    public Image frase3;
    public Image frase4;
    public Image frase5;

    public GameObject Proximo;

    void Start()
    {
        Proximo.SetActive(false);
    }

    void Update()
    {
        if (frase1.color == Color.green &&
            frase2.color == Color.green &&
            frase3.color == Color.green &&
            frase4.color == Color.green &&
            frase5.color == Color.green)
        {
            Proximo.SetActive(true);
        }
    }
}
