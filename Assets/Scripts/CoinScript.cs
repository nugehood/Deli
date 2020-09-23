using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    Rigidbody rb;
    Transform playerBody;
    PlayerBanks playerMoney;
    // Start is called before the first frame update
    void Start()
    {
        playerMoney = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBanks>();
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 2f);
    }

    private void OnDestroy()
    {
        playerMoney.allCoins += 1;
    }



}
