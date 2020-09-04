using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class itemMenuItem : MonoBehaviour
{
    [Header("Menu Item Script")]
    [Tooltip("Put your itemData Scriptableobject here")]
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
        //Check if the prefabs bool with the itemName it's equal to true or Unlocked
        //Then change the itemIcon to the itemSprt
        //And then it's already unlocked
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

    //Put inside OnClick()
    //When clicking on the Button
    public void ItemInfo()
    {

        //Check if when clicking
        //The object it's already Unlocked
        //Then change the text to the ItemData Info
        //Else change Image sprite to locked and Info is NULL
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


    //GetBool
    //Checked if playerPrefs with the name it's 1 then it's true
    //Otherwise(0) it's false or return a false value
    public static bool GetBool(string name)
    {
        return PlayerPrefs.GetInt(name) == 1 ? true : false;
    }
}


