using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class bubbleGum : MonoBehaviour
{
    Movement playerMovement;


    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }


    //If player touch bubble gum
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerMovement.speed = 2f;
            playerMovement.run_speed = 2f;
            playerMovement.jumpSpeed = 2f;
            playerMovement.bubbleGum = true;
            Destroy(gameObject);
        }
    }
}
