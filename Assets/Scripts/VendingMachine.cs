using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public int health;
    public GameObject[] drinks;
    public Transform spawnLocation;
    public Color normalOutline;
    public Color highlightOutline;
    public bool inUse;
    Animator animator;
    [HideInInspector]
    public int randomness;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {



        if(health <= 0)
        {
            animator.SetBool("des", true);
        }
    }
}
