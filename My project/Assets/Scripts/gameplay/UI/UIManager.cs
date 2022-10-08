using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region variables 
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
        menus[_currentMenu].DeActivate();
        if (menuLocation < 0)
        {
            return;
        }
        menus[menuLocation].Activate();
        _currentMenu = menuLocation;
    }
    #endregion use menu 
}
