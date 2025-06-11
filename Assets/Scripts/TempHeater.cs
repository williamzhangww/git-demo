using UnityEngine;
using TMPro;

public class TempHeater : MonoBehaviour
{
    public TextMeshProUGUI tempText;
    public float startTemp = 25f;
    public float targetTemp = 32f;
    public float heatDuration = 10f;
    public float coolDuration = 10f;
    public string handTag = "Hand";

    private float currentTemp;
    private float timer = 0f;
    private bool isHeating = false;

    void Start()
    {
        currentTemp = startTemp;
        UpdateDisplay();
    }

    void Update()
    {
        if (isHeating)
        {
            timer += Time.deltaTime;
            currentTemp = Mathf.Lerp(startTemp, targetTemp, timer / heatDuration);
            if (timer >= heatDuration) currentTemp = targetTemp;
        }
        else
        {
            timer -= Time.deltaTime;
            currentTemp = Mathf.Lerp(startTemp, targetTemp, timer / heatDuration);
            if (timer <= 0)
            {
                timer = 0;
                currentTemp = startTemp;
            }
        }

        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        tempText.text = currentTemp.ToString("F1") + " ¡ãC";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(handTag))
        {
            Debug.Log(">>> Hand Entered TouchZone");
            isHeating = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(handTag))
        {
            Debug.Log(">>> Hand Exited TouchZone");
            isHeating = false;
        }
    }
}
