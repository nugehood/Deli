using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class optionScript : MonoBehaviour
{

    public PauseScript pauseScript;

    public currWorldTime WorldTime;

    [Header("Mouse Properties")]
    public MouseLook mouseMovement;
    public Slider mouseSlider;
    


    [Header("Audio Properties")]
    public AudioMixer mixer;
    public Slider musicSlider;
    public Slider fxSlider;

    [Header("Display Properties")]
    int screenResIndex;
    int screenHeight, screenWidth;
    public Toggle fullscreenToggle;
    public Text resolutionText;

    [HideInInspector]
    public string screenRes;

    private void Awake()
    {
        mouseMovement.ableToZoom = false;
    }

    void Start()
    {
        //Default resolution on Start Game
        fullscreenToggle.isOn = true;
        screenHeight = Screen.currentResolution.height;
        screenWidth = Screen.currentResolution.width;
        Screen.SetResolution(screenWidth, screenHeight, fullscreenToggle.isOn);

    }

    void Update()
    {

        //Limit of screenIndex
        screenResIndex = Mathf.Clamp(screenResIndex, 0, 2);

        //Set resolution text to screenRes base on the switch case from Index!
        resolutionText.text = screenRes.ToString();


        //Switch case for screen resolution data and cycling resolution
        switch (screenResIndex)
        {
            case 0:
                screenWidth = 1280;
                screenHeight = 720;
                screenRes = "1280x720";
                break;
            case 1:
                screenWidth = 1366;
                screenHeight = 728;
                screenRes = "1366x728";
                break;

            case 2:
                screenWidth = 1920;
                screenHeight = 1080;
                screenRes = "1920x1080";
                break;
        }


    }



    public void SetSensitivity(float sliderValue)
    {
        mouseMovement.mouseSensitivity = sliderValue;
    }

    //Assign this method to nextRes button onClick()
    public void nextResolutionIndex()
    {
        screenResIndex += 1;
    }

    //Assign this method to preRes button onClick()
    public void previousResolutionIndex()
    {
        screenResIndex -= 1;
    }

    public void ApplySetting()
    {
        //Setting the resoltuion and fullscreen
        Screen.SetResolution(screenWidth, screenHeight, fullscreenToggle.isOn);

        //Close the optionMenu
        this.gameObject.SetActive(false);

        //Allow camera movement
        mouseMovement.enabled = true;

       
            //Don't show cursor
            Cursor.visible = false;

            //Lock cursor
            Cursor.lockState = CursorLockMode.Locked;
        

        //Unmute audio
        mixer.SetFloat("masterVol", 0);


        pauseScript.isPaused = false;

        //Able to use phone
        pauseScript.ablePause = true;

        mouseMovement.ableToZoom = true;

        //Revert back to normal time
        WorldTime.worldTime = 1;
    }

    
    //Revert to default setting
    public void DefaultSetting()
    {
        musicSlider.value = 0.43f;
        fxSlider.value = 0.22f;

        screenResIndex = 0;
        fullscreenToggle.isOn = true;
        mouseMovement.mouseSensitivity= 150;
        mouseSlider.value = 150;

    }
}