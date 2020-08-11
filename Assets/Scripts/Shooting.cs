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
    

    int scrollIndex;
    float throwSpeed;

    //Don't change value in Editor!
    public int newsPaperLimit;
    public int newspaperAmmo;
    int weaponMagazine;
    


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
        Mathf.Clamp(newspaperAmmo, 0, newsPaperLimit);

        ammoText.text = newspaperAmmo.ToString()+"/"+newsPaperLimit.ToString();

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

        Debug.Log(scrollIndex);
        

        //Change newspaper speed depending on Index
        switch (scrollIndex)
        {
            case 0:
                throwSpeed = 500;
                newsPaperLimit = 1;

                
                break;
            case 1:
                throwSpeed = 700;
                newsPaperLimit = 5;
                break;
            case 2:
                throwSpeed = 1000;
                newsPaperLimit = 10;
                break;
        }

        //Check if newspaper ammo is more than the limit
        //Then change ammo value to limit
        if(newspaperAmmo > newsPaperLimit)
        {
            newspaperAmmo = newsPaperLimit;
        }

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
                    //Check if ammo is full
                    if(newspaperAmmo < newsPaperLimit)
                    {
                        PickAmmo();
                        Destroy(hit.collider.gameObject);
                    }
                    else
                    {
                        Debug.Log("Ammo is Full!");
                    }
                }
            }
        }




        //Left mouse clicked
        if (Input.GetMouseButtonDown(0)&&newspaperAmmo > 0)
        {
            Shoot();
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
        newspaperAmmo -= 1;
        
        
    }

    //Refill ammo
    public void PickAmmo()
    {
        newspaperAmmo = newsPaperLimit;
       
    }
}
