using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveOnStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }
}