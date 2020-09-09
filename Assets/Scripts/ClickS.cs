using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickS : MonoBehaviour
{
    public GameObject GameScript;
    
    // Start is called before the first frame update
    void Start()
    {   
        Game Game = GameScript.GetComponent<Game>();
    }

    // ↓ При клике увеличивает счет(score) 
    void OnMouseDown()
    {
        Game.score += Game.bonus;
        GetComponent<Animator>().SetTrigger("Hit");
    }
}
