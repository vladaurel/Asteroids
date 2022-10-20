/**
 * Primary class - used as a base root for the game.
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineAsteroids : MonoBehaviour
{
    #region variables 
    // WYSIWYG - 
    public UIManager uiManager;

    // Singleton
    private static StateMachineAsteroids _instance;

    // ease of access 
    [System.NonSerialized]
    public static ProfileData PLAYER_PROFILE = null;
    [System.NonSerialized]
    public static ResourcesLoader RESOURCE_LOADER = null;

    // testing
    private bool _allowSave = true;
    #endregion variables 

    #region init 
    private void Awake()
    {
        Time.timeScale = 1.0f;
        /*if (_instance != null)
        {
            Debug.LogError("On Awake : There is already an instance of the statemachine ! this should never happen !");
            return;
        }*/
        _instance = this;

        RESOURCE_LOADER = gameObject.AddComponent<ResourcesLoader>();
        LoadSave();
    }

    public void LoadSave(string saveName = "default")
    {
        LoadData tempLoad = new LoadData();
        // tempLoad.CreateNewProfile(saveName);
        PLAYER_PROFILE = tempLoad.LoadProfile(saveName);
    }

    public void SaveGame(string saveName = "default")
    {
        if (!_allowSave)
        {
            return;
        }
        SaveData tempSave = new SaveData();
        tempSave.WriteProfileSave(saveName, PLAYER_PROFILE);
    }

    private void Start()
    {
        GameManagerAsteroids asteroidManager = gameObject.AddComponent<GameManagerAsteroids>();
        asteroidManager.Init(PLAYER_PROFILE);
    }
    #endregion init 


    #region functionality 
    public static StateMachineAsteroids Instance()
    {
        return _instance;
    }
    #endregion functionality 
}
