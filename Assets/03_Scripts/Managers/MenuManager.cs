using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ButtonStartGame()
    {
        SceneManager.LoadScene("Game");
        GameManage.instance.RestartHealth();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ButtonResetGame()
    {
        GameManage.instance.RestartHealth();
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
