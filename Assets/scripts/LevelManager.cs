using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    #region Singltone
    public static LevelManager Instanse;
    private void Awake()
    {
        if (Instanse == null)
            Instanse = this;
        else
            Destroy(gameObject);
    }
    #endregion
    public bool onRestart;
    public static UnityEvent NewGame = new UnityEvent();
    public static int CurrentScene => SceneManager.GetActiveScene().buildIndex;

    private void Start()
    {
        onRestart = false;
        Time.timeScale = 1;
    }

    public void Restart()
    {
        ChangeLvL(SceneManager.GetActiveScene().buildIndex);
        onRestart = true;
    }

    public void OnTriggerEnter2D()
    {
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
        EndLvL();
    }

    public void EndLvL()
    {
        ChangeLvL(1);
    }

    public void ChangeLvL(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public static int GetLastLevelIndex()
    {
        return PlayerPrefs.GetInt("level");
    }

    public void StartGame()
    {
        PlayerPrefs.GetInt("level", 0);
        PlayerPrefs.SetInt("level", 0);
        ChangeLvL(1);
    }

    public void ContinueGame()
    {
        ChangeLvL(1);
    }
}