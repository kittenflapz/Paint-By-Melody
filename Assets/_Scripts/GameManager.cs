using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public bool isCursorActive { get; private set; } = true;

    // singletonificiation

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    
    private void EnableCursor(bool enable)
    {
        if (enable)
        {
            isCursorActive = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            isCursorActive = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void OnEnable()
    {
        AppEvents.mouseCursorEnable += EnableCursor;
    }

    private void OnDisable()
    {
        AppEvents.mouseCursorEnable -= EnableCursor;
    }
}
