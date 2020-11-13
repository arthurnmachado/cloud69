using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Verificar : MonoBehaviour
{
    public Image fundo;
    private 


    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Frase_2"))
        {
            fundo.color = Color.green;
        }

        else
        {
            fundo.color = Color.red;
        }
    }
}