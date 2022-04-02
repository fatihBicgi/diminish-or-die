using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    private bool isPaused = false;


    [SerializeField] GameObject fightButtonObject;
    [SerializeField] GameObject jumpButtonObject;
    [SerializeField] GameObject runButtonObject;

    Image fightImage, jumpImage, runIimage;
    Button fightButton, jumpButton, runButton;

    [SerializeField] GameObject Char;
    PlayerMovement playerMovement;

    [SerializeField] GameObject LevelPoint;
    public NextLevelPoint nextLevelPoint;

    [SerializeField] GameObject Spear;

    public Transform firstLevelStartPoint, secondLevelStartPoint, lastLevelStartPoint;


    public bool isFightAbility = true, isJumpAbility = true, isRunAbility = true;

    // Start is called before the first frame update
    void Awake()
    {

        playerMovement = Char.GetComponent<PlayerMovement>();

        nextLevelPoint = LevelPoint.GetComponent<NextLevelPoint>();

        AbilitiesImageReferences();

        AbilitiesButtonReferences();

        AbilitiesButtonsEnabledFalse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AbilitiesImageReferences()
    {
        fightImage = fightButtonObject.GetComponent<Image>();
        jumpImage = jumpButtonObject.GetComponent<Image>();
        runIimage = runButtonObject.GetComponent<Image>();
    }

    private void AbilitiesButtonReferences()
    {
        fightButton = fightButtonObject.GetComponent<Button>();
        runButton = runButtonObject.GetComponent<Button>();
        jumpButton = jumpButtonObject.GetComponent<Button>();
    }


    public void DisableJump()
    {
        isJumpAbility = false;
        jumpImage.color = Color.red;
        pauseGame();
        SyncingDisabledAbilities();

        SpawnForCurrentLevel();

        AbilitiesButtonsEnabledFalse();

    }
    public void DisableRun()
    {
        isRunAbility = false;
        runIimage.color = Color.red;
        pauseGame();
        SyncingDisabledAbilities();

        SpawnForCurrentLevel();
        AbilitiesButtonsEnabledFalse();

    }
    public void DisableFight()
    {
        isFightAbility = false;
        fightImage.color = Color.red;
        pauseGame();
        SyncingDisabledAbilities();
        FightWeaponSetActiveFalse();

        SpawnForCurrentLevel();
        AbilitiesButtonsEnabledFalse();


    }
    private void FightWeaponSetActiveFalse()
    {
        Spear.SetActive(false);
    }
    public void AbilitiesButtonsEnabledTrue()
    {
        fightButton.enabled = true;
        jumpButton.enabled = true;
        runButton.enabled = true;
    }
    private void AbilitiesButtonsEnabledFalse()
    {
        fightButton.enabled = false;
        jumpButton.enabled = false;
        runButton.enabled = false;
    }
    private void SyncingDisabledAbilities()
    {
        playerMovement.fightAbility = isFightAbility;
        playerMovement.jumpAbility = isJumpAbility;
        playerMovement.runAbility = isRunAbility;
    }
    public void SpawnForCurrentLevel()
    {
        if (nextLevelPoint.currentLevel == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (nextLevelPoint.currentLevel == 2)
        {
            SpawnToSecondStartPoint();
        }
        else if (nextLevelPoint.currentLevel >= 3)
        {
            SpawnToLastStartPoint();
        }
    }


    private void SpawnToFirstStartPoint()
    {
        Char.transform.position = firstLevelStartPoint.transform.position;
    }
    private void SpawnToSecondStartPoint()
    {
        Char.transform.position = secondLevelStartPoint.transform.position;
    }
    private void SpawnToLastStartPoint()
    {
        Char.transform.position = lastLevelStartPoint.transform.position;
    }


    public void pauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;

        }
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
