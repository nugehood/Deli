using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class houseStates : MonoBehaviour
{
    //Debug purposes
    //Not included in the final product
    public Toggle deliveredTgl, failedTgl;

    [Space]
    public houseDelivered deliveredArea;
    public houseFailed failedArea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deliveredTgl.isOn = deliveredArea.isDelivered;
        failedTgl.isOn = failedArea.isFailed;

        //If is already failed
        //It cannot be delivered
        if (failedTgl.isOn)
        {
            deliveredArea.isDelivered = false;
        }
    }
}
