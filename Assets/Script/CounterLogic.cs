using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ClickLogic))]
public class CounterLogic : MonoBehaviour
{
    private ClickLogic _clickLogic;

    [SerializeField] private float _delay = 0.5f;

    private Coroutine _coroutine;

    private int _counter = 0;

    private bool _inProcess = false;

    public event Action<int> CounterChanged;  
    
    private void OnEnable()
    {
        _clickLogic = GetComponent<ClickLogic>();
        _clickLogic.ButtonClicked += ToggleCounting;
    }

    private void OnDisable()
    {
        _clickLogic.ButtonClicked -= ToggleCounting;
    }

    private void ToggleCounting(bool inProcess)
    {
        _inProcess = !_inProcess;

        if (_inProcess)
        {
            StartCounting();
        }
        else
        {
            StopCounting();
        }
    }

    private void StartCounting()
    {

        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(Counter(_delay));
        }
    }

    private void StopCounting()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = null;
    }

    private IEnumerator Counter(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (enabled)
        {
            _counter++;
            CounterChanged?.Invoke(_counter);
            yield return wait;
        }
    }
}