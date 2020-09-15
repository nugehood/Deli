using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Camera))]
public class Shooting : MonoBehaviour
{
    Camera cam;
    public float rayCastLength;
    Newspaper newPaper;
    Movement playerMovement;
    NewItemAchv achiveItem;
    ItemOnStatus itemOnStatus;
    MouseLook mouseLook;
    VendingMachine vending;
    MeshRenderer vendRenderer;

   [HideInInspector]
    public bool ableToScroll;
    public bool ableToShoot;
    public int scrollIndex;
    float throwSpeed;
    int i;

    [Header("Weapons Component")]
    public GameObject newspaper;
    public Transform spawnLocation;
    public TMP_Text ammoText;
    public int howMuchWeapon;
    public GameObject[] Weapons;
    public Image weaponIMG;
    public Sprite[] weaponsIcon;
    public int newspaperThrow, pistolThrow, smgThrow, rpgThrow, dualThrow;

    [Header("Weapons FX")]
    public GameObject muzzleFlash;
    public Transform[] muzzleFlashPos;
    public ShakeCamera shakeFX; 

    [Header("Weapons sounds")]
    public AudioSource fxSource;
    public AudioClip[] shootSFX;

    [Header("Items Component")]
    public GameObject itemIcon;
    public Transform itemGroup;
    public StatusTab statusTab;

    [Header("Unlockables and Achivements Component")]
    public GameObject newAchive;
    public Transform canvas;




    [Space]
    public GameObject itemInfoUI;
    public TMP_Text itemNameTx, itemDescTx, itemQuoteTx;
    public Image itemImage;

    [Space]
    public TMP_Text pickUpText;


    [HideInInspector]
    public int newsPaperLimit, pistolLimit, smgLimit, rpgLimit, dualLimit, howMuchItem;
    [HideInInspector]
    public int newspaperAmmo, pistolAmmo, smgAmmo, rpgAmmo, dualAmmo;

    int fullAmmo;




    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

        mouseLook = GetComponent<MouseLook>();

        //Equals to -1
        //Because we're already at 0 on scroll index
        //So when decreasing it will not go over the limit of the scrollIndex
        howMuchItem = -1;

        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();


        //Initialize to default value
        ableToShoot = true;
        ableToScroll = true;

        switch (scrollIndex)
        {
            case 0:
                throwSpeed = newspaperThrow;
                newsPaperLimit = 1;
                break;
        }

        newspaperAmmo = newsPaperLimit;





    }

    // Update is called once per frame
    void Update()
    {



        //Limit how much ammo can hold based on eachWeaponLimit(Max Value)
        newspaperAmmo = Mathf.Clamp(newspaperAmmo, 0, newsPaperLimit);

        pistolAmmo = Mathf.Clamp(pistolAmmo, 0, pistolLimit);

        smgAmmo = Mathf.Clamp(smgAmmo, 0, smgLimit);

        rpgAmmo = Mathf.Clamp(rpgAmmo, 0, rpgLimit);

        dualAmmo = Mathf.Clamp(dualAmmo, 0, dualLimit);

        //Limit the scrollValue/Number of availabe weapons
        scrollIndex = Mathf.Clamp(scrollIndex, 0, howMuchWeapon);

        //Scroll mouse up
        //Increase index Value
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && ableToScroll)
        {
            scrollIndex += 1;
            nextWeapon();
        }

        //Scroll mouse down
        //Decrease index Value
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && ableToScroll)
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
                throwSpeed = newspaperThrow;
                newsPaperLimit = 1;
                fullAmmo = newspaperAmmo;
                ammoText.text = fullAmmo.ToString() + "/" + newsPaperLimit.ToString();

                if (Input.GetMouseButtonDown(0) && newspaperAmmo > 0 && ableToShoot)
                {
                    Shoot();
                }

                break;
            case 1:
                throwSpeed = pistolThrow;
                pistolLimit = 5;
                fullAmmo = pistolAmmo;
                ammoText.text = fullAmmo.ToString() + "/" + pistolLimit.ToString();

                if (Input.GetMouseButtonDown(0) && pistolAmmo > 0 && ableToShoot)
                {
                    Shoot();

                    //Shake the camera
                    shakeFX.shake = true;
                    shakeFX.seconds = 0.2f;
                    shakeFX.shakeAmount = 1;

                    ShootSFX(shootSFX[scrollIndex]);
                    MuzzleFlash(muzzleFlashPos[scrollIndex]);
                }

                break;
            case 2:
                throwSpeed = smgThrow;
                smgLimit = 10;
                fullAmmo = smgAmmo;
                ammoText.text = fullAmmo.ToString() + "/" + smgLimit.ToString();


                if (Input.GetMouseButtonDown(0) && smgAmmo > 0 && ableToShoot)
                {
                    Shoot();

                    //Shake the camera
                    shakeFX.shake = true;
                    shakeFX.seconds = 0.3f;
                    shakeFX.shakeAmount = 1;

                    ShootSFX(shootSFX[scrollIndex]);
                    MuzzleFlash(muzzleFlashPos[scrollIndex]);
                }

                break;
            case 3:
                throwSpeed = rpgThrow;
                rpgLimit = 2;
                fullAmmo = rpgAmmo;
                ammoText.text = fullAmmo.ToString() + "/" + rpgLimit.ToString();


                if (Input.GetMouseButtonDown(0) && rpgAmmo > 0 && ableToShoot)
                {
                    //Shake the camera
                    shakeFX.shake = true;
                    shakeFX.seconds = 0.2f;
                    shakeFX.shakeAmount = 2;

                    Shoot();
                    Shoot();
                }

                break;
            case 4:
                throwSpeed = dualThrow;
                dualLimit = 10;
                fullAmmo = dualAmmo;
                ammoText.text = fullAmmo.ToString() + "/" + dualLimit.ToString();


                if (Input.GetMouseButtonDown(0) && dualAmmo > 0 && ableToShoot)
                {
                    Shoot();
                    ShootSFX(shootSFX[scrollIndex]);
                    ShootSFX(shootSFX[scrollIndex]);
                    MuzzleFlash(muzzleFlashPos[scrollIndex]);
                    MuzzleFlash(muzzleFlashPos[scrollIndex + 1]);
                    Shoot();
                }

                break;
        }


        //Reloading newspaper
        //Only the common first newspaper can acces this!
        if (Input.GetKeyDown(KeyCode.R) && newspaperAmmo <= newsPaperLimit)
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


        if (Physics.Raycast(ray, out hit, rayCastLength))
        {
            //If raycast enter obj with ammo Tag

            if (hit.collider.gameObject.CompareTag("ammo"))
            {
                pickUpText.text = "E";
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

                        case 3:
                            if (rpgAmmo < rpgLimit)
                            {
                                PickAmmo();
                                Destroy(hit.collider.gameObject);
                            }

                            else
                            {
                                Debug.Log("Ammo is full!");
                            }
                            break;

                        case 4:
                            if (dualAmmo < dualLimit)
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
            else
            {
                pickUpText.text = null;
            }


            //Pickup Items
            if (hit.collider.CompareTag("item"))
            {
                //Get Items from the raycast
                Items disItem = hit.collider.GetComponent<Items>();


                //Display item Info
                itemInfoUI.SetActive(true);

                //Change description text color on item type
                //For example AGILITY is YELLOW
                itemDescTx.color = disItem.item.typeColor;

                //Display Info
                itemNameTx.text = disItem.item.itemName.ToString();
                itemDescTx.text = disItem.item.itemDesc.ToString();
                itemQuoteTx.text = disItem.item.itemQuote.ToString();
                itemImage.sprite = disItem.item.itemSprt;

                if (Input.GetKeyDown(KeyCode.E))
                {

                    //Check if item is already Unlocked
                    //Else Playerprefs set the integer value of itemName
                    //It's true if int is 1 and otherwise

                    if (GetBool(disItem.item.itemName).Equals(true))
                    {
                        Debug.Log("ITEM ALREADY UNLOCKED!");
                        GameObject newItem = (GameObject)Instantiate(itemIcon, itemGroup);
                        itemOnStatus = newItem.GetComponent<ItemOnStatus>();
                        itemOnStatus.ItemData = disItem.item;
                        itemOnStatus.itemIcon.sprite = disItem.item.itemSprt;
                    }

                    else
                    {
                        PlayerPrefs.SetInt(disItem.item.itemName, true ? 1 : 0);
                        
                        //Get new item notif
                        GameObject newAch = (GameObject)Instantiate(newAchive, canvas);
                        achiveItem = newAch.GetComponent<NewItemAchv>();
                        achiveItem.nameText.text = disItem.item.name.ToString();
                        achiveItem.descText.text = disItem.item.achiveDesc.ToString();
                        achiveItem.itemImg.sprite = disItem.item.itemSprt;
                        
                    }


                    if (disItem.item.itemType.Equals("Agility"))
                    {
                        statusTab.agility += 0.2f % 2;
                    }

                    if (disItem.item.itemType.Equals("Accuracy"))
                    {
                        statusTab.accuracy += 0.1f % 2;
                    }

                    //Check if it's equals the name of the Item
                    //Then run the function or method
                    //That's inteded to use for the specific Item
                    //Pickup and then destroy obj
                    if (disItem.item.itemName.Equals("Energy Drink"))
                    {
                        
                        EnergyDrinks();
                        Destroy(hit.collider.gameObject);
                    }

                    if (disItem.item.itemName.Equals("Coffee"))
                    {
                        
                        Coffee();
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


            if (hit.collider.gameObject.CompareTag("vending"))
            {
                vendRenderer = hit.collider.gameObject.GetComponent<MeshRenderer>();
                vending = hit.collider.gameObject.GetComponent<VendingMachine>();
                vendRenderer.material.SetColor("_OutlineColor", vending.highlightOutline);

              

                if (Input.GetKeyDown(KeyCode.E)&&!vending.inUse)
                {
                    Animator venAnim = hit.collider.gameObject.GetComponent<Animator>();
                    vending.health -= 1;
                    vending.inUse = true;
                    venAnim.SetTrigger("use");
                    Invoke("StopShaking", 1.6f);
                }
                
            }
            else
            {
                vendRenderer.material.SetColor("_OutlineColor", vending.normalOutline);
            }



        }






    }

    public void StopShaking()
    {
        vending.inUse = false;
        vending.randomness = Random.Range(0, vending.drinks.Length);
        Instantiate(vending.drinks[vending.randomness], vending.spawnLocation.position, vending.spawnLocation.rotation);
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
    
    public void Coffee()
    {
        newspaperThrow += 5;
    }

    public void EnergyDrinks()
    {
        playerMovement.IncreaseRunSpeed();
    }


    public static bool GetBool(string name)
    {
        return PlayerPrefs.GetInt(name) == 1 ? true : false;
    }

    /**
     Spawn MuzzleFlash on the given position. 
        Each object/weapon has its own Child gameObject with muzzleFlash.
        Each position will always change depending on the active array based on scrollIndex.
    **/
    public void MuzzleFlash(Transform muzzlePos)
    {
        GameObject mFlash = (GameObject)Instantiate(muzzleFlash, muzzlePos.position, muzzlePos.rotation, muzzlePos.parent);

    }

    /**
     Play shooting sound. Will always change depending on the active array based on scrollIndex.
    **/
    public void ShootSFX(AudioClip sound)
    {
        fxSource.PlayOneShot(sound);
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
            case 3:
                rpgAmmo -= 1;
                newPaper.rocket = true;
                break;
            case 4:
                dualAmmo -= 1;
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
            case 3:
                rpgAmmo += 2;
                break;
            case 4:
                dualAmmo += 2;
                break;

        }


    }
}