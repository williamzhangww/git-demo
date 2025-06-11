using TMPro;
using UnityEngine;

public class TemperatureController : MonoBehaviour
{
    public TextMeshProUGUI tempValueText;
    public float currentTemp = 25.0f;
    public float step = 1f;

    void Start()
    {
        UpdateDisplay();
    }

    public void IncreaseTemp()
    {
        currentTemp += step;
        UpdateDisplay();
    }

    public void DecreaseTemp()
    {
        currentTemp -= step;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (tempValueText != null)
        {
            tempValueText.text = currentTemp.ToString("F1");
        }
    }
}
