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
           
            myVector = new Vector3(-3.982734f, -0.04373159f, 3.657505f);
            myRotation = new Quaternion(-2.938f, 89.751f, -3.153f, 0);
            //Instantiate(prefab, myVector, myRotation);
            Instantiate(prefab);
           // prefab.transform.position = myVector;
           // prefab.transform.rotation = myRotation;
        }
        else
        {
            Health = health;
        }
    }
}
