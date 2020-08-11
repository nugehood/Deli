using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Newspaper : MonoBehaviour
{
    Rigidbody rb;

    //Don't change value!
    [Tooltip("Leave default at 500!")]
    public float throwSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Give force/acceleration to this object when spawned
        rb.AddForce(transform.forward  * throwSpeed,ForceMode.Acceleration);
    }
}
