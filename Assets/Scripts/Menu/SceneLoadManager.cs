using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private string mainMenu;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
