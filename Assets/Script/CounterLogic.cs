using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterLogic : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;

    public event Action<int> CounterChanged;

    private Coroutine _coroutine;

    private int _counter = 0;
    private const int LeftMouseButton = 0;

    private bool _inProcess = false;

    public void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            Debug.Log("Left button pressed");
            ToggleCounting();
        }
    }

    private void ToggleCounting()
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