using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void SetTimer(int minutes)
    {
        _text.text = minutes.ToString(); //может сюда экшен нужен?
    }
}