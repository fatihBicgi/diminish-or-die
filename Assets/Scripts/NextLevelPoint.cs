using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelPoint : MonoBehaviour
{
    [SerializeField] GameObject objectOfButtonFunctions;
    ButtonFunctions buttonFunctions;

    [SerializeField] GameObject Char;
    [SerializeField] GameObject level_0, level_1, level_2;

    [SerializeField] Transform level_1_Finish, level_2_Finish;

    public int currentLevel;

    private void Awake()
    {
        buttonFunctions = objectOfButtonFunctions.GetComponent<ButtonFunctions>();
        currentLevel = 0;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            TranslateToNextLevel();

            currentLevel = currentLevel+1;

            
        }

    }

    private void TranslateToNextLevel()
    {
        if (currentLevel == 0)
        {
            Char.transform.position = buttonFunctions.secondLevelStartPoint.transform.position;
            OnlySecondLevelActive();
            transform.position = level_1_Finish.position;

        }
        else if (currentLevel == 2)
        {
            Char.transform.position = buttonFunctions.lastLevelStartPoint.transform.position;
            OnlyLastLevelActive();
            transform.position = level_2_Finish.position;
        }
    }

    private void OnlySecondLevelActive()
    {
        level_0.SetActive(false);
        level_1.SetActive(true);
        level_2.SetActive(false);
    }
    private void OnlyLastLevelActive()
    {
        level_0.SetActive(false);
        level_1.SetActive(false);
        level_2.SetActive(true);
    }
}
