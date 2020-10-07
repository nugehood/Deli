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
    public GameObject[] activeHouse;
    public int i;
    bool isCompleted;
    public int completeCounter, failedCounter;
    public int overallCounter;
    public float playerScore;
    float timer, finalTimer;


    [Header("UI Components")]
    public GameObject gameOverNotice;
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

       


    }

    
    // Update is called once per frame
    void Update()
    {
        activeHouse = GameObject.FindGameObjectsWithTag("active");
     
        playerScore = completeCounter + 5f - failedCounter / 0.2f;
        playerScore = Mathf.Clamp(playerScore, 0, playerScore);

        overallCounter = completeCounter + failedCounter;
        scoreText.text = playerScore.ToString();
        deliverText.text = completeCounter.ToString();
        failText.text = failedCounter.ToString();
        timeText.text = timer.ToString();

            /*
            GetTime();
            movement.walk_speed = 0;
            movement.enabled = false;
            cameraMovement.enabled = false;
            pauseScript.enabled = false;
            shooting.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            isCompleted = true;
            */


            if (completeCounter > failedCounter && overallCounter >= activeHouse.Length)
            {
                gameOverNotice.SetActive(true);
            }
            else if(failedCounter > completeCounter && overallCounter >= activeHouse.Length)
            {
                gameOverNotice.SetActive(true);
                //Invoke("CompleteGame",3);
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
