using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobbing : MonoBehaviour
{
    public Movement movement;

    public float walkingBobbingSpeed = 14f;
    public float bobbingAmount = 0.05f;

    float defaultPosY = 0;
    float timer = 0;

    void Start()
    {
        defaultPosY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {

        //Bobbing speed when Running
        if(movement.canRun && movement.tryRun)
        {
            walkingBobbingSpeed = 14f;
        }

        //Bobbing speed when not running
        else if(!movement.canRun && movement.tryRun)
        {
            walkingBobbingSpeed = 10f;
        }

        if (Mathf.Abs(movement.moveDirection.x) > 0.1f || Mathf.Abs(movement.moveDirection.z) > 0.1f)
        {
            //Player is moving
            timer += Time.deltaTime * walkingBobbingSpeed;

            //Move/bob the Y axis speed is equal to timer times walkingBobbingSpeed(The lower the slower)
            transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobbingAmount, transform.localPosition.z);
        }
        else
        {
            //Idle
            timer = 0;

            //Reset to default position
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * walkingBobbingSpeed), transform.localPosition.z);
        }
    }
}
