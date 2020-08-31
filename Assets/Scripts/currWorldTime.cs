using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currWorldTime : MonoBehaviour
{
    //Use for all in one time controls
    //So it does not need to be controlled independently each script
    public float worldTime;

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = worldTime;
    }
}
