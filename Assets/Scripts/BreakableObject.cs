using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public GameObject destroyedPrefabs;
    public AudioClip sfx;
    AudioSource sfxSource;

    private void Start()
    {
        sfxSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(destroyedPrefabs, transform.position, transform.rotation);
        sfxSource.PlayOneShot(sfx);
        Destroy(gameObject);
    }

}
