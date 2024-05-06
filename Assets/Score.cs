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
        txtCurrentScore.text = score.ToString();

        txtBestScore.text = PlayerPrefs.GetInt("HighScore",0).ToString();
        UpdateHighScore();
    }
    private void UpdateHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            txtBestScore.text = score.ToString();
        }
    }

    public void UpdateScore()
    {
        score++;
        txtCurrentScore.text = score.ToString();
        UpdateHighScore();
    }
}
