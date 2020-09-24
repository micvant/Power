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
    public Text btnTextBuyUpgrade;
    public Button[] shopBtn;

    [Header("Массив цен улучшений")]
    [Header("Улучшение клика")]
    private int shopCost = 50;
    [Header("Улучшение АвтоКлика")]
    private int costAutoClick = 100;
    private int costBonusTimer = 10;
    private int index = 0;
    public float bonusTime;
    public static int bonus = 1;
    public static int score;
    [Header("АвтоКликеры")]
    private int VacuumCounts, VacuumBonus = 1;
    private Save sv = new Save();

    // ↓ Перед стартом игры
    private void Awake()
    {
        // ↓ если есть файл сохранения то загружаем и присваиваем значения
        if (PlayerPrefs.HasKey("sv"))
        {
            sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("sv"));
            score = sv.score;
            VacuumCounts = sv.VacuumCounts;
            shopCost = sv.shopCost;
            costAutoClick = sv.costAutoClick;
            costBonusTimer = sv.costBonusTimer;
        }
    }
    void Start()
    {
        StartCoroutine(BonusPerSecond());
    }
    // ↓ Обновление каждого кадра + Обновление счета
    void Update()
    {
        scoreText.text = score + " $";
        btnTextUpgrade.text = $"Купить {shopCost} $";
        btnTextAutoClick.text = $"Купить {costAutoClick} $";
        btnTextBuyUpgrade.text = $"Купить {costBonusTimer} $";
        if (VacuumCounts >= 1)
        {
            try
            {
                // Bild.GetComponent<HealthBuild>().GetHit(1);
                // Bild.GetComponent<Animator>().SetTrigger("Hit");
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
        if (Input.GetKey("escape"))  // если нажата клавиша Esc (Escape)
        {
            Application.Quit();    // закрыть приложение
        }
    }
    // ↓ Перед выходом из игры Сохраняем прогресс
    void OnApplicationQuit()
    {
        sv.score = score;
        sv.VacuumCounts = VacuumCounts;
        sv.shopCost = shopCost;
        sv.costAutoClick = costAutoClick;
        sv.costBonusTimer = costBonusTimer;

        PlayerPrefs.SetString("sv", JsonUtility.ToJson(sv));
    }
    // ↓ Покупка улучшения клика
    public void buyUpgrade()
    {
        if (score >= shopCost)
        {
            // ↓ Добавляем +1$ при Клике
            bonus++;
            // ↓ Забираем деньги за покупку
            score -= shopCost;
            index++;
            // ↓ Увеличиваем цену в 2 раза 
            shopCost *= 2;
        }
        else
        {
            // ↓ Добавить вывод текста на экран "Не хватает денег!"
        }
    }

    // ↓ Использование бонуса удвоения
    public void startBonusTimer()
    {
        if (VacuumCounts >= 1)
        {
            if (score >= costBonusTimer)
            {
                score -= costBonusTimer;
                costBonusTimer++;
                StartCoroutine(BonusTimer(bonusTime));
            }
            else
            {
                Debug.Log("Not money!");
            }
        }
        else
        {
            Debug.Log("Not money!");
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
        if (score >= costAutoClick)
        {
            // ↓ Добавляем +1$ АвтоКлик
            VacuumCounts++;
            // ↓ Забираем деньги за покупку
            score -= costAutoClick;
            // ↓ Увеличиваем цену в 2 раза 
            costAutoClick *= 2;
        }
        else
        {
            Debug.Log("Error!");
            // ↓ Добавить вывод текста на экран "Не хватает денег!"
        }
    }

    // ↓ Прибавляет $ в зависимости от количества VacuumCounts
    IEnumerator BonusPerSecond()
    {
        while (true)
        {
            score = score + (VacuumCounts * VacuumBonus);
            yield return new WaitForSeconds(1);
        }
    }
    // ↓ Удваивает количество пылесосов
    IEnumerator BonusTimer(float time)
    {
        if (VacuumCounts >= 1)
        {
            for (int i = 0; i < shopBtn.Length; i++)
            {
                shopBtn[i].interactable = false;
            }

            VacuumBonus *= 2;
            yield return new WaitForSeconds(time);
            VacuumBonus /= 2;
            for (int i = 0; i < shopBtn.Length; i++)
            {
                shopBtn[i].interactable = true;
            }
        }
        else
        {
            Debug.Log(VacuumCounts);
            Debug.Log("Not Vacuums!");
        }
    }

}
// ↓ Файлы сохранения
[Serializable]
public class Save
{
    public int score;
    public int VacuumCounts;
    public int costAutoClick;
    public int costBonusTimer;
    public int shopCost;
}
