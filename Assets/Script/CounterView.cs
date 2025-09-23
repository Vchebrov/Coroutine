using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
       
    private CounterLogic _counterLogic;

    private void OnEnable()
    {
        _text.text = "0";

        if (_counterLogic == null)
            _counterLogic = GetComponent<CounterLogic>();

        if (_counterLogic != null)
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
