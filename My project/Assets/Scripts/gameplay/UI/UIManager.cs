using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region variables 
    public LifeHandler lifeHandler;

    [SerializeField]
    private Button _openBtn;

    [SerializeField]
    private List<GameObject> lives = new List<GameObject>();

    [SerializeField]
    private Text _scoreText;


    [Space(30)]
    public List<UIBaseMenu> menus = new List<UIBaseMenu>();

    private int _currentMenu = -1;
    #endregion variables 


    #region init 
    private void Awake()
    {
        _scoreText.text = "0";

        _openBtn.transform.position = new Vector2(35, 35);
    }
    #endregion init 


    #region use menu 
    /// <summary>
    /// 
    /// </summary>
    /// <param name="menuLocation"></param>
    public void ActivateMenu(int menuLocation)
    {
        if(_currentMenu == menuLocation)
        {
            return;
        }

        // close all menus
        if (_currentMenu >= 0)
        {
            menus[_currentMenu].DeActivate();
        }
        if (menuLocation < 0)
        {
            return;
        }
        menus[menuLocation].Activate();
        _currentMenu = menuLocation;
        Time.timeScale = 0;
    }

    public void CloseCurrentMenu()
    {
        if(_currentMenu>-1)
        {
            menus[_currentMenu].DeActivate();
        }
        _currentMenu = -1;

        Time.timeScale = 1;
    }
    #endregion use menu 


    #region updates 
    public void UpdateScore()
    {
        _scoreText.text = (StateMachineAsteroids.PLAYER_PROFILE.score * 10).ToString();
    }
    #endregion update 
}
