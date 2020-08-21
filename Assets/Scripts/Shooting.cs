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
    Newspaper newPaper;

    public TMP_Text ammoText;
    
    [HideInInspector]
    public int scrollIndex;
    float throwSpeed;

    [Header("Weapons Component")]
    public GameObject[] Weapons;
    public Image weaponIMG;
    public Sprite[] weaponsIcon;

  
    [HideInInspector]
    public int newsPaperLimit;
    [HideInInspector]
    public int newspaperAmmo,pistolAmmo,smgAmmo;
    int fullAmmo;




    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
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
        pistolAmmo = Mathf.Clamp(pistolAmmo, 0, newsPaperLimit);
        smgAmmo = Mathf.Clamp(smgAmmo, 0, newsPaperLimit);

        


        //Limit the scrollValue/Number of availabe weapons
        scrollIndex = Mathf.Clamp(scrollIndex, 0, 2);

        //Scroll mouse up
        //Increase index Value
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
          scrollIndex = (scrollIndex+ 1);
        }

        //Scroll mouse down
        //Decrease index Value
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
          scrollIndex = (scrollIndex - 1);
        }

        weaponIMG.sprite = weaponsIcon[scrollIndex];
        

        

       
        

        //Change newspaper speed depending on Index
        //Shooting when the ammo is greater than 0
        switch (scrollIndex)
        {
            case 0:
                throwSpeed = 500;
                newsPaperLimit = 1;
                fullAmmo = newspaperAmmo;

                Weapons[0].SetActive(true);
                Weapons[1].SetActive(false);
                Weapons[2].SetActive(false);
          
                if(Input.GetMouseButtonDown(0)&&newspaperAmmo > 0)
                {
                    Shoot();
                }
                
                break;
            case 1:
                throwSpeed = 700;
                newsPaperLimit = 5;
                fullAmmo = pistolAmmo;

                Weapons[0].SetActive(false);
                Weapons[1].SetActive(true);
                Weapons[2].SetActive(false);

                if (Input.GetMouseButtonDown(0) && pistolAmmo > 0)
                {
                    Shoot();
                }

                break;
            case 2:
                throwSpeed = 1000;
                newsPaperLimit = 10;
                fullAmmo = smgAmmo;

                Weapons[0].SetActive(false);
                Weapons[1].SetActive(false);
                Weapons[2].SetActive(true);

                if (Input.GetMouseButtonDown(0) && smgAmmo > 0)
                {
                    Shoot();
                }

                break;
        }

        ammoText.text = fullAmmo.ToString()+"/"+newsPaperLimit.ToString();

        

        Ray ray;
        ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;


        if(Physics.Raycast(ray, out hit, 5))
        {
            //If raycast enter obj with ammo Tag
            if (hit.collider.gameObject.CompareTag("ammo"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    switch (scrollIndex)
                    {
                        case 0:
                            if(newspaperAmmo < newsPaperLimit)
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
                            if (pistolAmmo < newsPaperLimit)
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
                            if (smgAmmo < newsPaperLimit)
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
        }




         

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
