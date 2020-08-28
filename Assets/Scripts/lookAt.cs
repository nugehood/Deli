using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAt : MonoBehaviour
{
    public Transform nextHouse;

    public void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(nextHouse.position.x, transform.position.y, nextHouse.position.z);

        transform.LookAt(nextHouse);
    }
}
