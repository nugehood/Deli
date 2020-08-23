using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menuScript : MonoBehaviour
{
    [Header("Changing Scene")]
    public float Delay;
    public Animator fader;
    bool fadeIn, fadeOut;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fader.SetBool("fadein", fadeIn);
        fader.SetBool("fadeout", fadeOut);
        Time.timeScale = 1f;

    }

    public void FadeIN()
    {
        fadeIn = true;
        fadeOut = false;
    }

    public void FadeOUT()
    {
        fadeOut = true;
        fadeIn = false;
    }

    public void loadScene(string sceneName)
    {
        StartCoroutine(delayLoad(sceneName,Delay));
    }

    public IEnumerator delayLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


  


}
