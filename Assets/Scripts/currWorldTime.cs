using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currWorldTime : MonoBehaviour
{
    public float worldTime;

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = worldTime;
    }
}
