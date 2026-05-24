using TMPro;
using UnityEngine;

public class ScoreCounterManager : MonoBehaviour
{
    [SerializeField] private TMP_Text counter;

    public void UpdateDisplay(float newText)
    {
        counter.text = newText.ToString();
    }
}
