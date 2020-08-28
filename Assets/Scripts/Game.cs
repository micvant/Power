using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public void OnClick()
    {        
        score++;
        scoreText.text = score + " $";
    }
}
