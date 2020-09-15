using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    //       ↓ Нажатая кнопка ↓ Не нажатая кнопка
    public Sprite layer_down, layer_up;

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = layer_down;   
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sprite = layer_up;
    }
}
