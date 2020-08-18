using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTimeScript : MonoBehaviour
{
    [Tooltip("Set how slow the game is")]
    public float slowmoTime;
    Movement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerMovement.isBulletTime = true;
            playerMovement.worldTimes = slowmoTime;
            Destroy(gameObject);
        }
    }
}
