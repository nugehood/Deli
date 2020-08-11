using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Ammo : MonoBehaviour
{

    Shooting shootScript;
    int givenAmmo;

    // Update is called once per frame
    void Update()
    {
        shootScript = GameObject.FindObjectOfType<Shooting>();
        givenAmmo = shootScript.newsPaperLimit;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player in!");
            
        }
    }

    public void RefillAmmo()
    {
        shootScript.newspaperAmmo = givenAmmo;
        Destroy(gameObject);
    }
}
