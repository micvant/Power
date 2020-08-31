using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject shopPanel;
    public Text scoreText;
    public Text btnTextUpgrade;

    [Header("Массив цен улучшений")]
    
    private int shopCost = 100;
    private int index = 0;
    private int bonus = 1;
    private int score;

    // ↓ Обновление каждого кадра + Обновление счета
    void Update()
    {
        scoreText.text = score + " $";
        btnTextUpgrade.text = "Buy + 1 click " + shopCost + " $";
    }

    // ↓ Покупка улучшения клика
    public void buyUpgrade()
    {
        if(score >= shopCost)
        {
            bonus ++;
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

    // ↓ При клике увеличивает счет(score) 
    public void OnClick()
    {        
        score += bonus;
    }
}
