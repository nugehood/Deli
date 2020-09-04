using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemOnStatus : MonoBehaviour
{

    public itemData ItemData;
    public Image itemIcon;
    public TMP_Text itemCount;
    public int totalCount;
    // Update is called once per frame
    void Update()
    {
        itemCount.text = totalCount.ToString();
        
    }
}
