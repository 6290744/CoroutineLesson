using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter counter;

    private void OnEnable()
    {
        counter.ValueChanged += UpdateText;
    }

    private void OnDisable()
    {
        counter.ValueChanged -= UpdateText;
    }

    private void UpdateText(int minutes)
    {
        _text.text = minutes.ToString();
    }
}