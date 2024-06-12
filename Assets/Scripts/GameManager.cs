using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    [SerializeField] private GameObject gameOverCanvas;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1.0f;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame()
    {
        Debug.Log("StartGame method called");
        SceneManager.LoadScene(1);
    }

    
   
}
