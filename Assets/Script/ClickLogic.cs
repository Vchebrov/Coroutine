using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickLogic : MonoBehaviour
{
    private const int ButtonIdentificator = 0;

    public event Action<bool> ButtonClicked;

    void Update()
    {
        if (Input.GetMouseButtonDown(ButtonIdentificator))
        {
            Debug.Log("Left button pressed");
            ButtonClicked?.Invoke(true);
        }
    }
}
