using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class itemMenuItem : MonoBehaviour
{
    public itemData Itemdata;
    public TMP_Text nameText,descText,rarText,typeText;
    public Image itemIcon, itemImg;
    public Sprite lockedSprt, itemSprt;
    bool alreadyUnlock;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(GetBool(Itemdata.itemName).Equals(true))
        {
            itemIcon.sprite = itemSprt;
            alreadyUnlock   = true;
        }
        else
        {
            itemIcon.sprite = lockedSprt;
            alreadyUnlock   = false;
        }




       

    }

    public void ItemInfo()
    {
        if (alreadyUnlock)
        {
            itemImg.sprite  = Itemdata.itemSprt;
            nameText.text   = Itemdata.itemName.ToString();
            descText.text   = Itemdata.itemDesc.ToString();
            typeText.text   = Itemdata.itemType.ToString();
            rarText.color   = Itemdata.typeColor;
            rarText.text    = "Rarity";
        }
        else
        {
            itemImg.sprite  = lockedSprt;
            nameText.text   = "LOCKED";
            descText.text   = null;
            typeText.text   = null;
            rarText.color   = Color.white;
        }
    }

    public static bool GetBool(string name)
    {
        return PlayerPrefs.GetInt(name) == 1 ? true : false;
    }
}


