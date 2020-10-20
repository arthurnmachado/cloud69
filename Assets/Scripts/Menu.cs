using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string Fase_1;

    public void MudarCena()
    {
        SceneManager.LoadScene(Fase_1);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
