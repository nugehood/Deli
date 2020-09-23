using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public int health;
    public Slider enemyBar;
    public GameObject enemyDrop;
    int randomDrop;
    Newspaper newspaper;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyBar.maxValue = health;
        randomDrop = Random.Range(0, 20);
    }

    private void Update()
    {
        enemyBar.value = health;
        if(health <= 0)
        {

            DropCoin(randomDrop);
            Destroy(gameObject);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("newspaper"))
        {
            newspaper = other.gameObject.GetComponent<Newspaper>();
            health -= newspaper.newspaperDamage;
            Destroy(other.gameObject);
            TurnRed();
        }
        
    }

    public void DropCoin(int coinNum)
    {
        for(int i = 0; i <= coinNum; i++)
        {
            GameObject itemClone = Instantiate(enemyDrop, transform.position, transform.rotation);
        }
    }

    public void TurnRed()
    {
        spriteRenderer.color = Color.red;
        Invoke("NormalColor", 0.5f);
    }

    public void NormalColor()
    {
        spriteRenderer.color = Color.white;
    }

}
