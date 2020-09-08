using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusTab : MonoBehaviour
{

    public bool alreadyPick;
    public ItemOnStatus[] itemOnTab;
    public GameObject tabObj;

    public TMP_Text agText, heText, acText;
    public float agility, health, accuracy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        agText.text = agility.ToString()+"%";
        heText.text = health.ToString() + "%";
        acText.text = accuracy.ToString() + "%";

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
