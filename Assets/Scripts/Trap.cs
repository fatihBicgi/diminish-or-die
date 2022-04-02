using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] GameObject objectOfButtonFunctions;
    ButtonFunctions buttonFunctions;

    // Start is called before the first frame update
    private void Awake()
    {
        buttonFunctions = objectOfButtonFunctions.GetComponent<ButtonFunctions>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "deadz" +"one")
        {
            buttonFunctions.AbilitiesButtonsEnabledTrue();
            buttonFunctions.pauseGame();
        }
        
       


    }
}
