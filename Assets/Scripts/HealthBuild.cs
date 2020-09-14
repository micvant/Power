using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuild : MonoBehaviour
{
    // ↓ Максимальное здоровье здания   
    public int maxHealth = 100;
    public int Health;

    public GameObject prefab;
    public GameObject MainCamera;
    
    void Start()
    {
        Health = maxHealth;
        GameObject.Find("HealthBar").GetComponent<HealthBar>().SetMaxHealth(maxHealth);
    }

    public void GetHit(int damage)
    {
        int health = Health - damage;
        GameObject.Find("HealthBar").GetComponent<HealthBar>().SetHealth(health);
        if (health <= 0)
        {
            Destroy(gameObject);   
            GameObject clone;
            clone = Instantiate(prefab);
            MainCamera.GetComponent<Game>().Bild = clone;        
        }
        else
        {
            Health = health;
        }
    }
}
