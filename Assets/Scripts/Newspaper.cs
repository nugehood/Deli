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
    public bool rocket;
    public ParticleSystem rocketTrails;
    public int newspaperDamage;

    // Start is called before the first frame update
    void Start()
    {
        var emission = rocketTrails.emission;
        rb = GetComponent<Rigidbody>();

        //Give force/acceleration to this object when spawned
        rb.AddForce(transform.forward  * throwSpeed,ForceMode.Acceleration);
        if (rocket)
        {
            emission .enabled = true;
        }
        else
        {
            emission.enabled = false;
        }
    }
}
