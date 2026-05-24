using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    private float currentScore;
    [SerializeField] private UnityEvent<float> scoreChange;

    public void GetMorePoints(Enemy morePoints)
    {
        currentScore += morePoints.scoreValue;
        scoreChange?.Invoke(currentScore);
    }
}
