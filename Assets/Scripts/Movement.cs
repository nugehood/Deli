using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    
    CharacterController characterController;
    

    [Tooltip("Set your character Speed")]
    public float movementSpeed;

    


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        //Get the Horizontal and Vertical Input value
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Create new vector3
        //Add the right/left movement multilpy with x Value
        //Add the forward movement multiply with the vertical, changing it to z Axis movement
        Vector3 move = transform.right * x + transform.forward * z;

        //Move character
        characterController.SimpleMove(move * movementSpeed);

    }
}
