using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;

    [SerializeField] private TextMeshProUGUI txtCurrentScore;
    [SerializeField] private TextMeshProUGUI txtBestScore;
    private int score;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        //CurrentText is set to score which is initially zero or null
        //BestScore is set to the high score text which is saved in the PlayerPrefs
        txtCurrentScore.text = score.ToString();
        txtBestScore.text = PlayerPrefs.GetInt("HighScore",0).ToString();
        UpdateHighScore();
    }
    private void UpdateHighScore()
    {

        //The highscore saved in PlayerPrefs is updated if the current score is higher than what is saved
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            txtBestScore.text = score.ToString();
        }
    }

    public void UpdateScore()
    {
        //Score is updated when the method is called
        //The high score is also checked/updated
        score++;
        txtCurrentScore.text = score.ToString();
        UpdateHighScore();
    }
}
