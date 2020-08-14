using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Movement))]

public class healthSystem : MonoBehaviour
{
    int health;

    [Tooltip("Maximum Health for the player also Starting value for health")]
    public int maxHealth;

    [Space]
    [Tooltip("Should be the same as the maxHealth value!")]
    public Image[] healthImage;
    public Sprite healthy;
    public Sprite damaged;

    // Start is called before the first frame update
    void Start()
    {
        //Start health with the maximum value
        health = maxHealth;

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

        Debug.Log("Available: " + health);
        
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


}
