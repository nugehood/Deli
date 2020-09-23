using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveWhen : MonoBehaviour
{
    MeshRenderer mainRender;
    Shooting camShoot;

    // Start is called before the first frame update
    void Start()
    {
        mainRender = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        camShoot = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Shooting>();
        if(camShoot.rpgAmmo <= 0)
        {
            mainRender.enabled = false;
        }
        else
        {
            mainRender.enabled = true;
        }
    }
}
