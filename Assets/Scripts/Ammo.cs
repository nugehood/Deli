using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Ammo : MonoBehaviour
{
    public int usage;
    public GameObject paper;
    Shooting shootScript;
    int givenAmmo;

    // Update is called once per frame
    void Update()
    {
        shootScript = GameObject.FindObjectOfType<Shooting>();
        givenAmmo = shootScript.newsPaperLimit;
        if(usage <= 0)
        {
            Destroy(paper);
            Destroy(this);
            gameObject.tag = "Untagged";
        }

    }

}
