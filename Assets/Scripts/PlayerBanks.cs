using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerBanks : MonoBehaviour
{
    public int allCoins;

    public TMP_Text valueText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        valueText.text = allCoins.ToString();
    }
}
