using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collision))]
public class houseDelivered : MonoBehaviour
{

    public bool isDelivered;
    Rigidbody[] rb;
    Newspaper[] bruh;

    

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("newspaper"))
        {
            isDelivered = true;
            rb = collision.collider.GetComponents<Rigidbody>();
            for(int i = 0; i <= rb.Length; i++)
            {
                rb[i].isKinematic = true;
            }

            for (int i = 0; i <= bruh.Length; i++)
            {
                bruh[i].rocket = false;
            }
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
