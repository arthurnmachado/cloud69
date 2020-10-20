using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Verificar : MonoBehaviour
{
    public Image imagem;
    
    void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Frase_2")
        {
            imagem.color = Color.green;
        }

        else
        {
            imagem.color = Color.red;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Frase_2")
        {
            imagem.color = Color.blue;
        }

        else
        {
            imagem.color = Color.blue;
        }
    }
}