
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTextManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;

    public void OnGameOverCall()
    {
        gameOverText.SetActive(true);
    }

    public void MainMenuClick()
    {
        gameOverText.SetActive(false);
        SceneManager.LoadScene(0);

    }
}