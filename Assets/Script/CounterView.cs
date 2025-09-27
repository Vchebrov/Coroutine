using System;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CounterLogic))]
public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private CounterLogic _counterLogic;

    private void OnEnable()
    {
        _text.text = "0";

        _counterLogic = GetComponent<CounterLogic>();
        _counterLogic.CounterChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _counterLogic.CounterChanged -= OnValueChanged;
    }

    private void OnValueChanged(int value)
    {
        _text.text = value.ToString();
    }
}
