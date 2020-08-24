using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collision))]
public class houseDelivered : MonoBehaviour
{

    public bool isDelivered;

    

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("newspaper"))
        {
            isDelivered = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("newspaper"))
        {
            isDelivered = false;
        }
    }

}
