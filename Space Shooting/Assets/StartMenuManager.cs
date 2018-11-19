using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour {

    private const string MainScene = "Main";

    public void ResumeGame()
    {
        if (PlayerPrefs.GetInt("IsGameStartedForTheFirstTime") == 0)
            PlayerManager.Instance.SetDefaults();
        PlayerPrefs.SetInt("IsGameStartedForTheFirstTime", 1);
        SceneManager.LoadScene(MainScene);
    }

    public void NewGame()
    {
        PlayerManager.Instance.SetDefaults();
        PlayerPrefs.SetInt("IsGameStartedForTheFirstTime", 1);
        SceneManager.LoadScene(MainScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
