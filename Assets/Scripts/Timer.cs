using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _interval = 0.5f;
    
    private Coroutine _coroutine;
    private bool _isActive = false;
    private int _counter = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isActive == false)
            {
                _coroutine = StartCoroutine(CountRoutine());
            }
            else
            {
                _isActive = false;
                
                StopCoroutine(_coroutine);
            }
        }
    }
    
    private IEnumerator CountRoutine()
    {
        _isActive = true;
        
        while (_isActive)
        {
            _counter ++;
            
            _text.text = _counter.ToString();
        
            yield return new WaitForSeconds(_interval);
        }
    }
}
