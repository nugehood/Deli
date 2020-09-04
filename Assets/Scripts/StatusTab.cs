using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusTab : MonoBehaviour
{
    public bool alreadyPick;
    public ItemOnStatus[] itemOnTab;
    public GameObject tabObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        itemOnTab = GameObject.FindObjectsOfType<ItemOnStatus>();
        if (Input.GetKey(KeyCode.Tab))
        {
            tabObj.SetActive(true);
        }
        else
        {
            tabObj.SetActive(false);
        }
    }
}
