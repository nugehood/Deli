using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class houseStates : MonoBehaviour
{
    Transform housePosition;

    [Space]
    public bool activeHouse;
    public int houseNumber;
    public houseDelivered[] deliveredArea;
    public houseFailed[] failedArea;
    public houseNavigation nextHouse;


    public bool houseComplete, houseFailed, nextDelivery;

    // Start is called before the first frame update
    void Start()
    {
        housePosition = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
    
        


        if (activeHouse)
        {
           
           

            //Check if one of the paper is delivered
            //Then the delivery on the house is Complete
            foreach (houseDelivered delivered in deliveredArea)
            {

                if (delivered.isDelivered)
                {
                    houseComplete = true;
                }

              

            }

            //Check if one of the paper is failed(Landed in a failed area)
            //Then it's not complete but failed
            foreach (houseFailed failed in failedArea)
            {
                //Failed delivery
                if (failed.isFailed)
                {
                    houseComplete = false;
                    houseFailed = true;
                }

            }

            //If the delivery is complete
            //And it is not yet delivering next paper
            //Then delivery is complete
            //Moving to next delivery

            if (houseComplete&&!nextDelivery)
            {
                nextHouse.DeliveryComplete();
                nextDelivery = true;
            }

            if (houseFailed && !nextDelivery)
            {
                nextHouse.DeliveryComplete();
                nextDelivery = true;
            }


        }
  
     





    }


}
