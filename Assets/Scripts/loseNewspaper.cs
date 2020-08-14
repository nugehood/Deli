using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class loseNewspaper : MonoBehaviour
{
    Shooting playerAmmo;

    // Start is called before the first frame update
    void Start()
    {
        playerAmmo = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Shooting>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            decreaseNewspaper();
            Destroy(gameObject);
        }
    }

    public void decreaseNewspaper()
    {
        //Lose newspaper ammo
        //Based on the active weapons
        switch (playerAmmo.scrollIndex)
        {
            case 0:
                playerAmmo.newspaperAmmo -= 1;

                break;
            case 1:
                playerAmmo.pistolAmmo -= 1;

                break;
            case 2:
                playerAmmo.smgAmmo -= 1;

                break;
        }
    }
}
