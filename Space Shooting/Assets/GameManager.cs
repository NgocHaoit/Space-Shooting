using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public GameObject winPanel, losePanel, pausePanel;
    private const string MainScene = "Main";
    private void Awake()
    {
        instance = this;
    }

    public void WinGame()
    {
        StartCoroutine(WinGameIE());
    }
    public void LoseGame()
    {
        StartCoroutine(LoseGameIE());
    }
    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void ReplayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BackMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(MainScene);
    }
    IEnumerator WinGameIE()
    {
        yield return new WaitForSeconds(3f);
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }
    IEnumerator LoseGameIE()
    {
        yield return new WaitForSeconds(3f);
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
