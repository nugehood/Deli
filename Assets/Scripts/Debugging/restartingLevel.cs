using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartingLevel : MonoBehaviour
{

  

    // Update is called once per frame
    void Update()
    {
        Scene currScene = SceneManager.GetActiveScene();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(currScene.name);
        }
    }
}
