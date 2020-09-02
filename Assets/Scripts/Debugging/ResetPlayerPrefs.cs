using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour
{
    public KeyCode key;

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            resetPrefs();
        }
    }

    public void resetPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
