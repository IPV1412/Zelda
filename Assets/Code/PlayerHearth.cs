using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para SceneManager

public class PlayerHearth : MonoBehaviour
{
    [SerializeField] private RawImage[] Heart;
    private int Contenedor;
    public string Lose;

    void Start()
    {
        Contenedor = Heart.Length;
        UpdateHearts();
    }

    void Update()
    {
        UpdateHearts(); 
        gameOver();
    }

    private void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.tag == "Enemy")
        {
            Contenedor--;
        }
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < Heart.Length; i++)
        {
            Heart[i].enabled = i < Contenedor;
        }
    }

    private void gameOver()
    {
        if (Contenedor <= 0)
        {
            SceneManager.LoadScene(Lose);
        }
    }
}

