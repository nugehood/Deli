using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseComponent;
    public bool isPaused, ablePause;
    public AudioMixer mixer;
    Shooting playerShoot;
    MouseLook mouseMovement;
    currWorldTime WorldTime;

    // Start is called before the first frame update
    void Start()
    {
        ablePause = true;
        WorldTime = GameObject.FindGameObjectWithTag("time").GetComponent<currWorldTime>();
        mouseMovement = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>();
        playerShoot = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
    
        //If is not paused yet and escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape)&&ablePause&&!isPaused)
        {
            pauseGame();
        }

        //If already paused
        else if(Input.GetKeyDown(KeyCode.Escape)&&!ablePause&&isPaused)
        {
            resumeGame();
        }

    }

    
    //Pausing game
    public void pauseGame()
    {
        isPaused = true;

        ablePause = false;

        mouseMovement.ableToZoom = false;

        playerShoot.ableToScroll = false;

        playerShoot.ableToShoot = false;

        //Mute audio
        mixer.SetFloat("MusicVol", -80);

        pauseComponent.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        WorldTime.worldTime = 0;
    }

    //Resuming gameplay
    public void resumeGame()
    {
        isPaused = false;

        mouseMovement.ableToZoom = true;

        playerShoot.ableToScroll = true;

        playerShoot.ableToShoot = true;

        ablePause = true;

        //Unmute Audio
        mixer.SetFloat("MusicVol", 0);

        pauseComponent.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        WorldTime.worldTime = 1;
    }

    //Return to Menu
    public void QuitMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }





}
