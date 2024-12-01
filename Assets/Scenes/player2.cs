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
        // �V�[�����̂��ׂẴ{�^�����擾
        Button[] buttons = FindObjectsOfType<Button>();

        foreach (Button button in buttons)
        {
            // �{�^���̃N���b�N�C�x���g�Ƀ��\�b�h��ǉ�
            button.onClick.AddListener(() => OnButtonClick(button));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnButtonClick(Button button)
    {
        SceneManager.LoadScene("vs_2");
    }

}