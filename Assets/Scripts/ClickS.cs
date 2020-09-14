using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickS : MonoBehaviour
{
    public GameObject GameScript; 
    
    // ↓ При клике увеличивает счет(score) 
    void OnMouseDown()
    {
        Game.score += Game.bonus;
        GetComponent<Animator>().SetTrigger("Hit");
        GetComponent<HealthBuild>().GetHit(10);
    }
}
