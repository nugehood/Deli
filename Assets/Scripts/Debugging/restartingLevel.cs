using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartingLevel : MonoBehaviour
{

    Scene currScene;

    // Update is called once per frame
    void Update()
    {
        currScene = SceneManager.GetActiveScene();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RestartLevel();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currScene.name);
    }
}
