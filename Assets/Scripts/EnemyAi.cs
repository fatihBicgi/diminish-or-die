using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAi : MonoBehaviour
{
    [SerializeField] GameObject objectOfButtonFunctions;
    ButtonFunctions buttonFunctions;

    private void Awake()
    {
        buttonFunctions = objectOfButtonFunctions.GetComponent<ButtonFunctions>();

    }
    void Update()
    {
        

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            buttonFunctions.AbilitiesButtonsEnabledTrue();
            buttonFunctions.pauseGame();
        }
        else if (other.tag == "spear")
        {
            Destroy(gameObject);
        }

        
    }
   

    

}
    
