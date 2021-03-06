using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(lookAt))]
public class houseNavigation : MonoBehaviour
{
    public TMP_Text houseNumText;
    public lookAt arrowIndicator;
    public houseStates[] houses;

    [HideInInspector]
    public int nextHouseNum;
    bool startFirst;

    // Start is called before the first frame update
    void Start()
    {
        startFirst = true;


    }

    // Update is called once per frame
    void Update()
    {
        houses = GameObject.FindObjectsOfType<houseStates>();
        if (startFirst)
        {
            
            houses = GameObject.FindObjectsOfType<houseStates>();

            nextHouseNum = Random.Range(0, houses.Length);
            if (houses[nextHouseNum].activeHouse && houses[nextHouseNum].enabled && !houses[nextHouseNum].houseComplete
            && !houses[nextHouseNum].houseFailed)
            {
                arrowIndicator.nextHouse = houses[nextHouseNum].transform;
                houseNumText.text = houses[nextHouseNum].houseNumber.ToString();
            }

            else
            {

                Invoke("DeliveryComplete", 0);

            }
            startFirst = false;
        }
    }

    //If delivery is complete
    //Move to another random availabe active House
    public void DeliveryComplete()
    {
       //Generate random number with the max value of houses array length
       nextHouseNum = Random.Range(0, houses.Length);
       Debug.Log("Current house: " + nextHouseNum);

        //Check if the house is active bool and it is enable.
        //See if the houses is not yet delivered and failed
        //Then this house can be used for the next location!

        if (houses[nextHouseNum].activeHouse && houses[nextHouseNum].enabled && !houses[nextHouseNum].houseComplete
            && !houses[nextHouseNum].houseFailed)
        {
            arrowIndicator.nextHouse = houses[nextHouseNum].transform;
            houseNumText.text = houses[nextHouseNum].houseNumber.ToString();
        }
     
        else {

            Invoke("DeliveryComplete",0);

        }



    }
}
