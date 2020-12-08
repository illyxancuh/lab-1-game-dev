using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    protected LevelManager LvLManager;

    [SerializeField] protected GameObject menu;

    [Header("Menu buttons")]
    [SerializeField] protected UnityEngine.UI.Button lvlmenu;
    [SerializeField] protected UnityEngine.UI.Button quit;

    protected virtual void Start()
    {
        LvLManager = LevelManager.Instanse;
        lvlmenu.onClick.AddListener(OnLvlmenuClicked);
        quit.onClick.AddListener(OnQuitClicked);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeMenuStatus();
        }
    }

    protected virtual void OnDestroy()
    {
        lvlmenu.onClick.RemoveListener(OnLvlmenuClicked);
        quit.onClick.RemoveListener(OnQuitClicked);
    }

    protected virtual void ChangeMenuStatus()
    {
        menu.SetActive(!menu.activeInHierarchy);
        Time.timeScale = menu.activeInHierarchy ? 0 : 1;
    }

    public void OnLvlmenuClicked()
    {
        LvLManager.ChangeLvL(0);
    }

    public void OnQuitClicked()
    {
        LvLManager.Quit();
    }
}
