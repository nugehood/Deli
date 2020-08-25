using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class houseStates : MonoBehaviour
{
    Transform housePosition;

    [HideInInspector]
    public Toggle on, off;

    [Space]
    public bool activeHouse;
    public int houseNumber;
    public houseDelivered[] deliveredArea;
    public houseFailed[] failedArea;

    bool houseComplete, houseFailed;

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
            foreach (houseDelivered delivered in deliveredArea)
            {
                //Check if one of the paper is failed
                foreach (houseFailed failed in failedArea)
                {
                    //Entered deliver area
                    if (delivered.isDelivered && !failed.isFailed)
                    {
                        houseComplete = true;
                    }

                    //Leaving deliver area
                    else if (!delivered.isDelivered)
                    {
                        houseComplete = false;
                    }

                    //Failed delivery
                    else if (failed.isFailed)
                    {
                        houseComplete = false;
                        houseFailed = true;
                    }

                }
            }
        }


      
   
           

        
    }

}
