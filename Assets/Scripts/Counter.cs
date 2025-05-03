using System.Collections;
using UnityEngine;
using System;

public class Counter : MonoBehaviour
{
    private const int LeftMouseButton = 0;
    
    [SerializeField] private float _updateInterval = 0.5f;
    
    private Coroutine _coroutine;
    private bool _isActive = false;
    private int _value = 0;
    
    public event Action<int> ValueChanged;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            if (_isActive == false)
            {
                _isActive = true;
                
                _coroutine = StartCoroutine(UpdateValue());
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
    
    private IEnumerator UpdateValue()
    {
        WaitForSeconds wait = new WaitForSeconds(_updateInterval);
        
        while (_isActive)
        {
            _value++;
            
            ValueChanged?.Invoke(_value);

            yield return wait;
        }
    }
}
