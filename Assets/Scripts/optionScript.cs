using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class optionScript : MonoBehaviour
{
    [Header("Global usage")]
    public PauseScript pauseScript;
    public currWorldTime WorldTime;

    [Header("Mouse Properties")]
    public MouseLook mouseMovement;
    public Shooting playerShooting;
    public Slider mouseSlider;
    


    [Header("Audio Properties")]
    public setVolume volSet;
    public AudioMixer mixer;
    public Slider musicSlider;
    public Slider fxSlider;

    [Header("Display Properties")]
    int screenResIndex;
    int screenHeight;
    int screenWidth;
    public Toggle fullscreenToggle;
    public Text resolutionText;

    [HideInInspector]
    public string screenRes;

    


    private void Awake()
    {

        //If player is available
        //Then use mouse and camera configuration
        if (mouseMovement&&playerShooting&&pauseScript)
        {
            pauseScript.ablePause = false;
            pauseScript.isPaused = true;

            mouseMovement.ableToZoom = false;
            playerShooting.ableToShoot = false;
            playerShooting.ableToScroll = false;
        }
    }

    void Start()
    {
        //Default resolution on Start Game
        if (fullscreenToggle)
        {
            fullscreenToggle.isOn = GetBool("full");
            screenHeight = PlayerPrefs.GetInt("height",720);
            screenWidth = PlayerPrefs.GetInt("width",1280);
        }
        Screen.SetResolution(screenWidth, screenHeight, fullscreenToggle.isOn);
        musicSlider.value = PlayerPrefs.GetFloat("musicVol");
        fxSlider.value = PlayerPrefs.GetFloat("fxVol");
        screenRes = PlayerPrefs.GetString("res");
        screenResIndex = PlayerPrefs.GetInt("resindex");
    }

    void Update()
    {

       

        if (Input.GetKey(KeyCode.Escape))
        {
            gameObject.SetActive(false);

            //Don't show cursor
            Cursor.visible = false;

            //Lock cursor
            Cursor.lockState = CursorLockMode.Locked;
        }

        //If using the Display Option (AVAILABLE)
        if (fullscreenToggle && resolutionText)
        {

            screenRes = PlayerPrefs.GetString("res");
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
                    PlayerPrefs.SetString("res", "1280x720");
                   
                    break;
                case 1:
                    screenWidth = 1366;
                    screenHeight = 728;
                    PlayerPrefs.SetString("res", "1366x728");
                    break;

                case 2:
                    screenWidth = 1920;
                    screenHeight = 1080;
                    PlayerPrefs.SetString("res", "1920x1080");
                    break;
            }
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


        if (fullscreenToggle)
        {
            PlayerPrefs.SetInt("resindex", screenResIndex);
            PlayerPrefs.SetInt("width", screenWidth);
            PlayerPrefs.SetInt("height", screenHeight);
            PlayerPrefs.SetString("res", screenRes);
            PlayerPrefs.SetInt("full", fullscreenToggle.isOn ? 1 : 0);
            //Setting the resoltuion and fullscreen
            Screen.SetResolution(screenWidth, screenHeight, fullscreenToggle.isOn);
        }

        //Close the optionMenu
        gameObject.SetActive(false);

        //Unmute audio
        mixer.SetFloat("masterVol", 0);

        //If no Player components
        //Usage only for MENU
        if (mouseMovement&&playerShooting&&pauseScript&&WorldTime)
        {
            pauseScript.isPaused = false;

            //Able to pause again
            pauseScript.ablePause = true;

            //Allow camera movement
            mouseMovement.enabled = true;

            playerShooting.ableToScroll = true;

            //Allow Shooting
            playerShooting.ableToShoot = true;


            //Don't show cursor
            Cursor.visible = false;

            //Lock cursor
            Cursor.lockState = CursorLockMode.Locked;

            //Able to use phone
            pauseScript.ablePause = true;

            //Allow to zoom weapons, etc
            mouseMovement.ableToZoom = true;

            //Revert back to normal time
            WorldTime.worldTime = 1;

        }


    }

    
    //Revert to default setting
    public void DefaultSetting()
    {
        musicSlider.value = 0.43f;
        fxSlider.value = 0.22f;
        PlayerPrefs.SetFloat("fxVol", 0.22f);
        PlayerPrefs.SetFloat("musicVol", 0.43f);

        screenResIndex = 0;
        if (fullscreenToggle)
        {
            PlayerPrefs.SetInt("full", true ? 1 : 0);
            fullscreenToggle.isOn = true;
        }
        if (mouseMovement && pauseScript && WorldTime)
        {
            mouseMovement.mouseSensitivity = 150;
            mouseSlider.value = 150;
        }

    }

    //GetBool
    //Checked if playerPrefs with the name it's 1 then it's true
    //Otherwise(0) it's false or return a false value
    public static bool GetBool(string name)
    {
        return PlayerPrefs.GetInt(name) == 1 ? true : false;
    }
}
