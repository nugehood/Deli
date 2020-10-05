using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObject : MonoBehaviour
{
    public float horizontalSpeed,verticalSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate( Vector3.right * verticalSpeed * Time.deltaTime+ Vector3.up, horizontalSpeed * Time.deltaTime);
    }
}
