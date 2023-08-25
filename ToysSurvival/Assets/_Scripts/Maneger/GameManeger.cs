using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    #region SingleTon
    public static GameManeger Instance;
    public bool isStart;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public GameSaving save;
    private void Start()
    {
        GamePause();
    }
    public void GamePause()
    {
        isStart = false;
        Time.timeScale = 0;
    }
    public void GameResume()
    {
        isStart = true;
        Time.timeScale = 1;
    }
    public void PlayAgain()
    {
        save.Score = -1;
        save.time = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
