using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public int score = 0;


    public TextMeshProUGUI CurrentScoreText;
    public TextMeshProUGUI BestScoreText;
    public TextMeshProUGUI BestText;
    public GameObject TouchToStartText;

    public GameObject GameOverPanel;
    public GameObject GameOverEffectPanel;

    [HideInInspector]
    public bool isStarted = false;



    static int PlayCount;



    void Awake()
    {
        Application.targetFrameRate = 60;

        Time.timeScale = 1.0f;
        BestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();


    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isStarted == false)
        {
            isStarted = true;
            TouchToStartText.SetActive(false);
        }
    }


    public void addScore()
    {
        score++;
        CurrentScoreText.text = score.ToString();

        if (score > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", score);
            BestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        }
    }


    public void Gameover()
    {
        StartCoroutine(GameoverCoroutine());
    }


    IEnumerator GameoverCoroutine()
    {
        CurrentScoreText.color = Color.white;
        BestScoreText.color = Color.white;
        BestText.color = Color.white;

        GameOverEffectPanel.SetActive(true);
        Time.timeScale = 0.1f;
        yield return new WaitForSecondsRealtime(0.5f);
        GameOverPanel.SetActive(true);
        yield break;
    }



    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
