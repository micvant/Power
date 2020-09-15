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
        // ↓ Устанавливаем максимальное кол-во ХП
        GameObject.Find("HealthBar").GetComponent<HealthBar>().SetMaxHealth(maxHealth);
    }
    // ↓ Получение урона
    public void GetHit(int damage)
    {
        int health = Health - damage;
        // ↓ Устанавливаем Хдоровье в ХП баре
        GameObject.Find("HealthBar").GetComponent<HealthBar>().SetHealth(health);
        if (health <= 0)
        {
            // ↓ Уничтожение здания
            Destroy(gameObject);   
            // ↓ Создание здания
            GameObject clone = Instantiate(prefab);
            MainCamera.GetComponent<Game>().Bild = clone;        
        }
        else
        {
            Health = health;
        }
    }
}
