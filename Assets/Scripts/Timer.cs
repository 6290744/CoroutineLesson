using System.Collections;
using UnityEngine;

[RequireComponent(typeof(TimerView))]

public class Timer : MonoBehaviour
{
    [SerializeField] private float _interval = 0.5f;
    [SerializeField] private TimerView _timerView;
    
    private Coroutine _coroutine;
    private bool _isActive = false;
    private int _counter = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isActive == false)
            {
                _isActive = true;
                
                _coroutine = StartCoroutine(CountRoutine());
            }
            else
            {
                _isActive = false;

                if (_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                }
            }
        }
    }
    
    private IEnumerator CountRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_interval);
        
        while (_isActive)
        {
            _counter ++;
            
            _timerView.SetTimer(_counter);

            yield return wait;
        }
    }
}
