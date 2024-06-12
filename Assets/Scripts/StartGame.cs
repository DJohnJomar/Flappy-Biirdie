using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
   public void GameStart()
    {
        Debug.Log("Button Clicked");
        SceneManager.LoadScene(1);
    }
}
