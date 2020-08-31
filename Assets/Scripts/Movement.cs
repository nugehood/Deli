using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    [Header("Basic Value")]
    public float walk_speed = 6.0f;
    public float run_speed = 10f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float runDuration = 100f;
    public float runRegenTime = 15.0f;
    public Slider runMeter;
    float runDurationRecorder;

    [HideInInspector]
    public bool canRun = true;
    public bool tryRun = false;

    [HideInInspector]
    public Vector3 moveDirection = Vector3.zero;
    public CharacterController characterController;

    [Header("Hazardous effect")]
    public bool otherHazard;
    public bool bubbleGum;
    public float slownessDuration = 5f;

    [Header("Bullet Time")]
    public float worldTimes = 1f;
    public bool isBulletTime;
    public float bulletTimeDuration = 5f;
    currWorldTime WorldTime;

    public void Start()
    {
        WorldTime = GameObject.FindGameObjectWithTag("time").GetComponent<currWorldTime>();
        characterController = GetComponent<CharacterController>();
        StartCoroutine(energyRun());
        StartCoroutine(HazardEffect());
        speed = walk_speed;
        runDurationRecorder = 5;
    }
        

    private void Update()
    {


        //Debuggin stuff
        //Debug.Log("Running? "+canRun);
        //Debug.Log("BubbleGum: " + bubbleGum);

        //runMeter value limit(runDurationRecorder only appear as value for increasing and decreasing slider value)
        runDurationRecorder = Mathf.Clamp(runDurationRecorder, 0f, runDuration);

       
        //runMeter is equal to runDurationRecorder
        runMeter.value = runDurationRecorder;


        //Check if player is on the ground
        if (characterController.isGrounded)
        {
            //Get the input direction
            //Transform is now based on the input
            //moveDirection is multiplied with speed/movement speed
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            //Jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
            }

            //Running
            if (Input.GetKey(KeyCode.LeftShift))
            {
                tryRun = true;
                if (canRun)
                {
                    speed = run_speed;
                    runDurationRecorder -= Time.deltaTime;
                }

                else if (!canRun)
                {
                   
                    speed = walk_speed;
                    runDurationRecorder += Time.deltaTime;

                }
            }
            else
            {
                speed = walk_speed;
                runDurationRecorder += Time.deltaTime;

            }

           
           
        


           

            //Entered bullet time
            if (isBulletTime)
            {
                WorldTime.worldTime = worldTimes;
            }

        }
        //Able to move while on air
        else
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), moveDirection.y, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.x *= speed;
            moveDirection.z *= speed;
        }

        

        //Players gravity
        moveDirection.y -= gravity * Time.deltaTime;

        //Allows player to move to certain direction
        characterController.Move(moveDirection * Time.deltaTime);
    }

    public void IncreaseRunSpeed()
    {
        run_speed += 0.1f;
    }

    //Check if player can run 
    IEnumerator energyRun()
    {
        while (true)
        {
  
            if (tryRun)
            {
                while (canRun)
                {
                    //While running start duration for running
                    //Then Player can't run
                    
                    yield return new WaitForSeconds(runDuration);
                    canRun = false;
                }
                while (!canRun)
                {
                    //Regen fill up energy
                    //If energy is refill then canRun
                    
                    yield return new WaitForSeconds(runRegenTime);
                    canRun = true;
                }
            }

            while (!canRun)
            {
                //Regen fill up energy
                //If energy is refill then canRun

                yield return new WaitForSeconds(runRegenTime);
                canRun = true;
            }

            yield return new WaitForEndOfFrame();
        }
    }



    IEnumerator HazardEffect()
    {
        while (true)
        {
            //If player touch bubbleGum
            //Slowness effect accur
            while (bubbleGum)
            {
                yield return new WaitForSeconds(slownessDuration);
                bubbleGum = false;
                speed = 6.0f;
                run_speed = 10f;
                jumpSpeed = 8f;
            }

            //While player is in bullet time
            //Countdown with bulletTimeDuration
            //Then back to normal
            while (isBulletTime)
            {
                yield return new WaitForSeconds(bulletTimeDuration);
                isBulletTime = false;
                WorldTime.worldTime = 1;

            }

            yield return new WaitForEndOfFrame();

        }
    }

}
