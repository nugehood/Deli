using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSway : MonoBehaviour
{
    //Amount of available mouseMovement
    public float amount = 0.02f;

    //Limit of mouseMovement
    public float maxamount = 0.03f;

    //Smooth rotation
    public float smooth = 3;

    //Original localRotation
    private Quaternion def;

    //If Stopped
    private bool Paused = false;

    void Start()
    {
        //Get original rotation of Object
        def = transform.localRotation;
    }

    void Update()
    {

        //X factor time amount value
        float factorX = (Input.GetAxis("Mouse Y")) * amount;

        //Y factor time amount value
        float factorY = -(Input.GetAxis("Mouse X")) * amount;
        //float factorZ = -Input.GetAxis("Vertical") * amount;
        float factorZ = 0 * amount;


        //If moved
        if (!Paused)
        {
            //If the mouse movement is more than the maxamount(Moving right value)
            //Then set the value to the maxamount (Stay on the limit)
            if (factorX > maxamount)
                factorX = maxamount;

            //If the mouse movement is less than negative maxamount(Moving left value)
            //Then set it to the maxamount value

            if (factorX < -maxamount)
                factorX = -maxamount;

            if (factorY > maxamount)
                factorY = maxamount;

            if (factorY < -maxamount)
                factorY = -maxamount;

            if (factorZ > maxamount)
                factorZ = maxamount;

            if (factorZ < -maxamount)
                factorZ = -maxamount;
            
            //Final rotation to set the object rotation
            //Original rotation are added by the factor, that changes everytime
            //Then set the localrotation to the given Quaternion(Final)
            //Quaternion slerp, is for smoothing rotation!
            Quaternion Final = Quaternion.Euler(def.x + factorX, def.y + factorY, def.z + factorZ);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Final, (Time.time * smooth));
        }
    }
}
