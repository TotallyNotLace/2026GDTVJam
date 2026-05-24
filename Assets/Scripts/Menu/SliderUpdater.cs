using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text sliderCounter;

    public void UpdateText(float value)
    {
        float newValue = value * 100f;
        sliderCounter.text = newValue.ToString("F0");
    }

}
