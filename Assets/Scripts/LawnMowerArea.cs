using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class LawnMowerArea : MonoBehaviour
{
    public GameObject lawnMower;
    public Transform spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(lawnMower, spawnPos.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
