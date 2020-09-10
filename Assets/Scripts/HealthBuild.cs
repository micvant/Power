using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuild : MonoBehaviour
{
    // ↓ Максимальное здоровье здания   
    public int maxHealth = 100;
    public int Health;
    public HealthBar healthBar;
    public Transform prefab;
    
    Quaternion myRotation;
    Vector3 myVector;

    void Start()
    {
        Health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void GetHit(int damage)
    {
        int health = Health - damage;
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            Destroy(gameObject);
           
            myVector = new Vector3(0.06f, 1.22f, 0.88f);
            myRotation = new Quaternion(18f, 234f, 22f, 0);
            Instantiate(prefab, myVector, myRotation);
        }
        else
        {
            Health = health;
        }
    }
}
