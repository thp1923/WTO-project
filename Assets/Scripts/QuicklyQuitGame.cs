﻿using System.Collections;
using TMPro;
using UnityEngine;

public class ExitGamePrompt : MonoBehaviour
{
    public TextMeshProUGUI exitMessage; // Tham chiếu đến UI Text cho thông báo
    private bool isExiting = false;

    private void Start()
    {
        exitMessage.gameObject.SetActive(false);
    }
    void Update()
    {
        // Kiểm tra nếu nhấn phím Esc và chưa trong trạng thái thoát
        if (Input.GetKeyDown(KeyCode.Escape) && !isExiting)
        {
            StartCoroutine(ExitGameRoutine()); // Bắt đầu Coroutine để thoát game
        }
    }

    IEnumerator ExitGameRoutine()
    {
        isExiting = true;
        exitMessage.gameObject.SetActive(true); // Hiện thông báo thoát

        yield return new WaitForSeconds(3f); // Đợi 3 giây

        Application.Quit(); // Thoát game (không hoạt động trong chế độ Editor)

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Chỉ dành cho Editor
#endif
    }
}

