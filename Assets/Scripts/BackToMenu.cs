using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {

        Application.LoadLevel("Menu");

    }
}
