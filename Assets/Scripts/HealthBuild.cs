using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuild : MonoBehaviour
{
    // ↓ Максимальное здоровье здания   
    public int maxHealth = 100;
    public int Health;
    public HealthBar healthBar;

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
        }
        else
        {
            Health = health;
        }
    }
}
