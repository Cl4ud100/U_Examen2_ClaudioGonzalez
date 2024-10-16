using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public static GameManage instance;

    public int health = 100;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("GameObject is destroy");
        }
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void decreasedHealth(int amount)
    {
        health -= amount;
        Debug.Log("This is your new health: " + health);
        if (health <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over, Fin del Juego");
        SceneManager.LoadScene("GameOver");
        Cursor.lockState = CursorLockMode.None;

    }

    public void RestartHealth()
    {
        health = 100;
        Cursor.lockState = CursorLockMode.Locked;
    }



}
