using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Movement))]

public class healthSystem : MonoBehaviour
{
    int health;

    float worldTime;

    PauseScript playerPause;

    currWorldTime WorldTime;

    MouseLook mouseMovement;

    [Tooltip("Maximum Health for the player also Starting value for health")]
    public int maxHealth;

    [Space]
    [Tooltip("Should be the same as the maxHealth value!")]
    public Image[] healthImage;
    public Sprite healthy;
    public Sprite damaged;

    [Space]
    public GameObject gameOverUI;
    public Transform playerBody;
    public Transform respawnLocation;
    bool isRespawn;


    // Start is called before the first frame update
    void Start()
    {
        //Start health with the maximum value
        health = maxHealth;

        playerPause = GameObject.FindGameObjectWithTag("Player").GetComponent<PauseScript>();

        WorldTime = GameObject.FindGameObjectWithTag("time").GetComponent<currWorldTime>();

        mouseMovement = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>();

        //Set all images sprite to Healthy
        for(int i = 0;i <= healthImage.Length; i++)
        {
            healthImage[i].sprite = healthy;
        }
        
    }

    // Update is called once per frame
    void Update()
    {


        //Limit the minimum and maximum health
        health = Mathf.Clamp(health, 0, maxHealth);

        //Debug.Log("Available: " + health);

        if(health <= 0)
        {
            GameOver();
        }
        
        if (isRespawn)
        {
            playerBody.transform.position = respawnLocation.transform.position;
            gameOverUI.SetActive(false);
            isRespawn = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {


        //If Player has entered a hazard GameObject
        if (other.gameObject.CompareTag("hazard"))
        {
            decreaseHealth();
            Destroy(other.gameObject);
        }

        //If Player has entered a health GameObject
        else if (other.gameObject.CompareTag("health"))
        {
            increaseHealth();
            Destroy(other.gameObject);

        }
    }

    //Increase health by 1
    //Changing the sprite of health Images to healthy depends on the health value
    public void increaseHealth()
    {
        healthImage[health].sprite = healthy;
        health += 1;
        
    }


    //Decrease health by 1
    //Changing the sprite of health Images to damaged depends on the health value
    public void decreaseHealth()
    {
        health -= 1;
        healthImage[health].sprite = damaged;
    }

    public void GameOver()
    {
        playerPause.ablePause = false;
        gameOverUI.SetActive(true);

        mouseMovement.ableToZoom = false;
        

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        WorldTime.worldTime = 0;
    }

    public void RestartLevel()
    {

        WorldTime.worldTime = 1;

        health += 3;

        mouseMovement.ableToZoom = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerPause.ablePause = true;
        isRespawn = true;
        healthImage[0].sprite = healthy;
        healthImage[1].sprite = healthy;
        healthImage[2].sprite = healthy;
        healthImage[3].sprite = healthy;

        
    }


}
