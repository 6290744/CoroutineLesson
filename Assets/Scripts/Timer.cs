using System.Collections;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    private const int LeftMouseButton = 0;
    
    [SerializeField] private float _interval = 0.5f;
    
    private Coroutine _coroutine;
    private bool _isActive = false;
    private int _counter = 0;
    
    public event Action<int> TimerChanged;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            if (_isActive == false)
            {
                _isActive = true;
                
                _coroutine = StartCoroutine(CountdownRoutine());
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
    
    private IEnumerator CountdownRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_interval);
        
        while (_isActive)
        {
            _counter++;
            
            TimerChanged?.Invoke(_counter);

            yield return wait;
        }
    }
}
