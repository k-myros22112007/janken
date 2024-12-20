using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using static global;

public class player2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // シーン内のすべてのボタンを取得
        Button[] buttons = FindObjectsOfType<Button>();

        foreach (Button button in buttons)
        {
            // ボタンのクリックイベントにメソッドを追加
            button.onClick.AddListener(() => OnButtonClick(button));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnButtonClick(Button button)
    {
        SceneManager.LoadScene("vs2");
    }

}
