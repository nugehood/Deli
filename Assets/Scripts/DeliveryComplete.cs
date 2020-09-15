using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeliveryComplete : MonoBehaviour
{
    Movement movement;
    MouseLook cameraMovement;
    PauseScript pauseScript;
    Shooting shooting;
    public houseStates[] allHouses;
    int i;
    public int completeCounter, failedCounter;
    int overallCounter;
    public float playerScore;
    float timer, finalTimer;


    [Header("UI Components")]
    public GameObject scoreDisplay;
    public TMP_Text conditionText;
    public TMP_Text deliverText;
    public TMP_Text failText;
    public TMP_Text timeText;
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {

        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();

        pauseScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PauseScript>();

        cameraMovement = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>();

        shooting = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Shooting>();

        allHouses = GameObject.FindObjectsOfType<houseStates>();

        foreach (houseStates activehouse in allHouses)
        {
            if (activehouse.activeHouse)
            {
                i++;
            }
        }
        
    }


    // Update is called once per frame
    void Update()
    {

       
        
        playerScore = completeCounter + 5f - failedCounter / 0.2f;
        playerScore = Mathf.Clamp(playerScore, 0, playerScore);

        overallCounter = completeCounter + failedCounter;
        scoreText.text = playerScore.ToString();
        deliverText.text = completeCounter.ToString();
        failText.text = failedCounter.ToString();
        timeText.text = timer.ToString();

        if(overallCounter >= i)
        {
            GetTime();
            movement.enabled = false;
            cameraMovement.enabled = false;
            pauseScript.enabled = false;
            shooting.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            if (completeCounter > failedCounter)
            {
                CompleteGame();
            }
            else
            {
                FailedGame();
            }
        }

        else
        {
            timer += Time.deltaTime;
        }
    }
    
    public void GetTime()
    {
        finalTimer = timer;
    }

    public void CompleteGame()
    {
        ShowBoard("YOU WIN!");
    }

    public void FailedGame()
    {
        ShowBoard("YOU LOSE!");
    }

    public void ShowBoard(string condition)
    {
        scoreDisplay.SetActive(true);
        conditionText.text = condition.ToString();
    }
}
