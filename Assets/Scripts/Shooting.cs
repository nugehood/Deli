using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Camera))]
public class Shooting : MonoBehaviour
{
    Camera cam;
    public GameObject newspaper;
    public Transform spawnLocation;
    public TMP_Text ammoText;
    Newspaper newPaper;
    Movement playerMovement;

    [HideInInspector]
    public bool ableToScroll;
    public bool ableToShoot;
    public int scrollIndex;
    float throwSpeed;
    int i;

    [Header("Weapons Component")]
    public int howMuchWeapon;
    public GameObject[] Weapons;
    public Image weaponIMG;
    public Sprite[] weaponsIcon;




    [Space]
    public GameObject itemInfoUI;
    public TMP_Text itemNameTx, itemDescTx, itemQuoteTx;
    public Image itemImage;


    [HideInInspector]
    public int newsPaperLimit, pistolLimit, smgLimit, howMuchItem;
    [HideInInspector]
    public int newspaperAmmo, pistolAmmo, smgAmmo;


    int fullAmmo;




    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

        howMuchItem = -1;

        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();

        ableToShoot = true;
        ableToScroll = true;

        switch (scrollIndex)
        {
            case 0:
                throwSpeed = 500;
                newsPaperLimit = 1;
                break;
        }

        newspaperAmmo = newsPaperLimit;


        


    }

    // Update is called once per frame
    void Update()
    {
        //Limit how much ammo can hold based on newsPaperLimit(Max Value)
        newspaperAmmo = Mathf.Clamp(newspaperAmmo, 0, newsPaperLimit);
        pistolAmmo = Mathf.Clamp(pistolAmmo, 0, pistolLimit);
        smgAmmo = Mathf.Clamp(smgAmmo, 0, smgLimit);

        //Limit the scrollValue/Number of availabe weapons
        scrollIndex = Mathf.Clamp(scrollIndex, 0, howMuchWeapon);
       
        //Scroll mouse up
        //Increase index Value
        if (Input.GetAxis("Mouse ScrollWheel") > 0&&ableToScroll)
        {
            scrollIndex += 1;
            nextWeapon();
        }

        //Scroll mouse down
        //Decrease index Value
        if (Input.GetAxis("Mouse ScrollWheel") < 0&&ableToScroll)
        {
            scrollIndex -= 1;
            prevWeapon();
        }

        //Weapon IMG changes with the scrollIndex
        weaponIMG.sprite = weaponsIcon[scrollIndex];


        //Change newspaper speed depending on Index
        //Shooting when the ammo is greater than 0
        switch (scrollIndex)
        {
            case 0:
                throwSpeed = 500;
                newsPaperLimit = 1;
                fullAmmo = newspaperAmmo;
                ammoText.text = fullAmmo.ToString() + "/" + newsPaperLimit.ToString();
           
                if (Input.GetMouseButtonDown(0) && newspaperAmmo > 0&&ableToShoot)
                {
                    Shoot();
                }

                break;
            case 1:
                throwSpeed = 700;
                pistolLimit = 5;
                fullAmmo = pistolAmmo;
                ammoText.text = fullAmmo.ToString() + "/" + pistolLimit.ToString();

                if (Input.GetMouseButtonDown(0) && pistolAmmo > 0 && ableToShoot)
                {
                    Shoot();
                }

                break;
            case 2:
                throwSpeed = 1000;
                smgLimit = 10;
                fullAmmo = smgAmmo;
                ammoText.text = fullAmmo.ToString() + "/" + smgLimit.ToString();


                if (Input.GetMouseButtonDown(0) && smgAmmo > 0 && ableToShoot)
                {
                    Shoot();
                }

                break;
        }


        //Reloading newspaper
        //Only the common first newspaper can acces this!
        if (Input.GetKeyDown(KeyCode.R)&&newspaperAmmo <= newsPaperLimit)
        {
            newspaperAmmo += 1;
        }
        else
        {
            Debug.Log("Ammo is already FULL!");
        }

        Ray ray;
        ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, 5))
        {
            //If raycast enter obj with ammo Tag
            if (hit.collider.gameObject.CompareTag("ammo"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    switch (scrollIndex)
                    {
                        case 0:
                            if (newspaperAmmo < newsPaperLimit)
                            {
                                PickAmmo();
                                Destroy(hit.collider.gameObject);
                            }

                            else
                            {
                                Debug.Log("Ammo is full!");
                            }
                            break;

                        case 1:
                            if (pistolAmmo < pistolLimit)
                            {
                                PickAmmo();
                                Destroy(hit.collider.gameObject);
                            }

                            else
                            {
                                Debug.Log("Ammo is full!");
                            }
                            break;
                        case 2:
                            if (smgAmmo < smgLimit)
                            {
                                PickAmmo();
                                Destroy(hit.collider.gameObject);
                            }

                            else
                            {
                                Debug.Log("Ammo is full!");
                            }
                            break;
                    }
                }
            }


            //Pickup Items
            if (hit.collider.CompareTag("item"))
            {
                Items disItem = hit.collider.GetComponent<Items>();
                
                //Display item Info
                itemInfoUI.SetActive(true);

                //Change description text color on item type
                //For example AGILITY is YELLOW
                itemDescTx.color = disItem.item.typeColor;


                itemNameTx.text  = disItem.item.itemName.ToString();
                itemDescTx.text  = disItem.item.itemDesc.ToString();
                itemQuoteTx.text = disItem.item.itemQuote.ToString();
                itemImage.sprite = disItem.item.itemSprt;

                if (Input.GetKeyDown(KeyCode.E))
                {
                        if(disItem.item.itemName.Equals("Energy Drink"))
                        {
                            EnergyDrinks();
                            Destroy(hit.collider.gameObject);
                        }
                    
                    else
                    {
                        Debug.Log("SLOT FULL!!");
                        
                    }


                }
            }
            else
            {
                //Reset item info value
                itemNameTx.text = null;
                itemDescTx.text = null;
                itemQuoteTx.text = null;
                itemImage.sprite = null;
                itemInfoUI.SetActive(false);
            }


        }






    }

    //Next weapons in the array
    //Active the next weapon object (i + 1) without changing the value
    //Then the current index which is i(Still the original value, not yet being added), will get deactive
    //And increase the i index and the it will change it's value! (Same also applies for the prevWeapon)
    


    public void nextWeapon()
    {
        Weapons[i + 1].SetActive(true);
        Weapons[i].SetActive(false);
        i += 1;
    }

    public void prevWeapon()
    {
        Weapons[i - 1].SetActive(true);
        Weapons[i].SetActive(false);
        i -= 1;

    }

    public void EnergyDrinks()
    {
        playerMovement.IncreaseRunSpeed();
    }
  

    public void Shoot()
    {
        //Spawn new newspaper
        //Get the new newspaper component
        //Change their throwSpeed value to the given throwSpeed based on Index
        GameObject newObj = (GameObject)Instantiate(newspaper, spawnLocation.position, spawnLocation.rotation);
        newPaper = newObj.GetComponent<Newspaper>();
        newPaper.throwSpeed = throwSpeed;
        switch (scrollIndex)
        {
            case 0:
                newspaperAmmo -= 1;

                break;
            case 1:
                pistolAmmo -= 1;

                break;
            case 2:
                smgAmmo -= 1;

                break;
        }




    }

    //Refill ammo
    public void PickAmmo()
    {

        //Refill which ammo depends on active weapon Index
        switch (scrollIndex)
        {
            case 0:
                newspaperAmmo += 1;
                break;
            case 1:
                pistolAmmo += 1;

                break;
            case 2:
                smgAmmo += 2;
                break;

        }


    }
}