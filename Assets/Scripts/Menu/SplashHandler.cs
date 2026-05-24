using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SplashHandler : MonoBehaviour
{
    [SerializeField] private Image logo;
    [SerializeField] private float fadeSpeed;
    [SerializeField] private UnityEvent fadeInComplete;
    [SerializeField] private UnityEvent fadeOutComplete;

    private void Start()
    {
        logo.color = new Color(1f, 1f, 1f, 0f);
        StartCoroutine(FadeIn(1));
    }

    private IEnumerator FadeIn(int direction)
    {
        bool isFading = true;
        while (isFading)
        {
            float newAlpha = logo.color.a + fadeSpeed * Time.deltaTime * direction;
            logo.color = new Color(1f, 1f, 1f, newAlpha);

            if (logo.color.a >= 1f || logo.color.a <= 0f)
            {
                isFading = false;
            }
            yield return new WaitForEndOfFrame();
        }
        if(direction > 0)
        {
            fadeInComplete?.Invoke();
        }
        else
        {
            fadeOutComplete?.Invoke();
        }
        
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeIn(-1));
    }
}
