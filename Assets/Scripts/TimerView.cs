using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        Timer.OnTimerChanged += SetTimer;
    }

    private void OnDisable()
    {
        Timer.OnTimerChanged -= SetTimer;
    }

    private void SetTimer(int minutes)
    {
        _text.text = minutes.ToString();
    }
}