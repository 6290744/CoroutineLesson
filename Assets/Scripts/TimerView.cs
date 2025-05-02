using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Timer _timer;

    private void OnEnable()
    {
        _timer.TimerChanged += UpdateText;
    }

    private void OnDisable()
    {
        _timer.TimerChanged -= UpdateText;
    }

    private void UpdateText(int minutes)
    {
        _text.text = minutes.ToString();
    }
}