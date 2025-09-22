using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private Coroutine _coroutine;

    private int _counter = 0;
    private bool _inProcess = false;

    private float _delay = 0.5f;

    private void Start()
    {
        _text.text = "0";
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleCounting();
        }
    }

    private void ToggleCounting()
    {
        if (_inProcess)
        {
            StopCoroutine(_coroutine);
            _inProcess = false;
        }
        else
        {
            _coroutine = StartCoroutine(CountTime(_delay));
            _inProcess = true;
        }
    }

    private IEnumerator CountTime(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            _counter++;
            _text.text = _counter.ToString();
        }
    }
}
