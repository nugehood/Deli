using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnSeconds : MonoBehaviour
{

    public float destroySeconds;

    void Update()
    {
        Destroy(gameObject, destroySeconds);
    }



}
