using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BookManager : MonoBehaviour
{
    [SerializeField] private UnityEvent splashLoadComplete;
    [SerializeField] private float splashWait;
    [SerializeField] private SettingsDataManagement settings;

    private void Start()
    {
        StartCoroutine(SplashLoadSequence());
    }

    private IEnumerator SplashLoadSequence()
    {
        yield return new WaitForSeconds(splashWait/2);
        settings.LoadSettings();
        yield return new WaitForSeconds(splashWait/2);
        splashLoadComplete?.Invoke();
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene("testscene");
    }


    public void QuitButton()
    {
        Application.Quit();
    }
}
