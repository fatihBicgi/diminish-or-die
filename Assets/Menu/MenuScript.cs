using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);

    }

    public void QuitButton()
    {
        Debug.Log("Oyundan ciktik");
        Application.Quit();
    }
   
}
