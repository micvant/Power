using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    //       ↓ Нажатая кнопка ↓ Не нажатая кнопка
    public Sprite layer_down, layer_up;

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = layer_down;
        SceneManager.LoadScene("SampleScene");
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sprite = layer_up;
    }
}
