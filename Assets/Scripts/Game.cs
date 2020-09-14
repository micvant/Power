using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Game : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject Bild;
    public Text scoreText;
    public Text btnTextUpgrade;
    public Text btnTextAutoClick;

    [Header("Массив цен улучшений")]    
    [Header("Улучшение клика")]
    private int shopCost = 100;
    [Header("Улучшение АвтоКлика")]
    private int costAutoClick = 10;

    private int index = 0;
    public static int bonus = 1;
    public static int score;
    [Header("АвтоКликеры")]
    private int VacuumCounts;

    void Start()
    {
        StartCoroutine(BonusPerSecond());
    }
    // ↓ Обновление каждого кадра + Обновление счета
    void Update()
    {
        scoreText.text = score + " $";
        btnTextUpgrade.text = "Купить " + shopCost + " $";
        btnTextAutoClick.text = "Купить " + costAutoClick + " $";
        if(VacuumCounts >= 1)
        {
            try
            {
                //Bild.GetComponent<HealthBuild>().GetHit(1);
                //Bild.GetComponent<Animator>().SetTrigger("Hit");
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
    }

    // ↓ Покупка улучшения клика
    public void buyUpgrade()
    {
        if(score >= shopCost)
        {
            // ↓ Добавляем +1$ при Клике
            bonus++;
            // ↓ Забираем деньги за покупку
            score -= shopCost;
            index++;
            // ↓ Увеличиваем цену в 2 раза 
            shopCost *= 2;
        }  else
        {
            // ↓ Добавить вывод текста на экран "Не хватает денег!"
        }
    }

    // ↓ Открытие/Закрытие магазина улучшений
    public void openShop()
    {
        shopPanel.SetActive(!shopPanel.activeSelf);
    }

    // Покупка ↓ АвтоКлика
    public void BuyVacuum()
    {
        if(score >= costAutoClick)
        {
            // ↓ Добавляем +1$ АвтоКлик
            VacuumCounts++;
            // ↓ Забираем деньги за покупку
            score -= costAutoClick;
            // ↓ Увеличиваем цену в 2 раза 
            costAutoClick *= 2;
        }else
        {
            // ↓ Добавить вывод текста на экран "Не хватает денег!"
        }
    }

    // ↓ Прибавляет $ в зависимости от количества VacuumCounts
    IEnumerator BonusPerSecond()
    {
        while (true)
        {
            score += VacuumCounts;
            yield return new WaitForSeconds(1);
        }
    }

}
