using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAt : MonoBehaviour
{
    public Transform housetest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(housetest.position.x, transform.position.y, housetest.position.z);

        transform.LookAt(housetest);
    }
}
