using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseGenerator : MonoBehaviour
{
    public houseLocation[] houseLocations;
    public houseStates[] housing;
    public GameObject[] houses;
    int randomSpawn;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        houseLocations = GameObject.FindObjectsOfType<houseLocation>();
        housing = GameObject.FindObjectsOfType<houseStates>();
        
        foreach(houseLocation houseLocation in houseLocations)
        {
            if (housing.Length < houseLocations.Length)
            {
                if (!houseLocation.GetComponentInParent<houseStates>())
                {
                    //Spawn house based on random given value
                    randomSpawn = Random.Range(0, 5);
                    int randomNum = Random.Range(5, 1000);
                    
                    var randomActive = (Random.value < 0.5);
                    GameObject houseIndex = (GameObject)Instantiate(houses[randomSpawn],
                        houseLocation.transform.position, houseLocation.transform.rotation);
                    houseStates houseState = houseIndex.GetComponent<houseStates>();
                    houseState.activeHouse = randomActive;
                    houseState.houseNumber = randomNum;
                }
            }

            else
            {

            }
        }
    }

}
