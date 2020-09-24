using UnityEngine;

public class ClickS : MonoBehaviour
{
    public GameObject GameScript;

    // ↓ При клике увеличивает счет(score) 
    void OnMouseDown()
    {
        Game.score += Game.bonus;
        // ↓ Включение анимации
        GetComponent<Animator>().SetTrigger("Hit");
        // ↓ Нанесение урона
        GetComponent<HealthBuild>().GetHit(1);
    }
}
