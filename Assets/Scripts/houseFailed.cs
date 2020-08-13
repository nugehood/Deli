using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houseFailed : MonoBehaviour
{
    public bool isFailed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("newspaper"))
        {
            isFailed = true;
        }
    }
}
