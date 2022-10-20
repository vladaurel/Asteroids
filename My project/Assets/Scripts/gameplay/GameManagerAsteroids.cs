/**
 * Serves as a secondary root. 
 * Contains all the managers within the game. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerAsteroids : MonoBehaviour
{
    #region variables 
    private static GameManagerAsteroids _instance = null;

    public PlayerManager playerManager; // player manager - contains player, player controls 
    public AsteroidManager asteroidManager; // asteroid manager - contains asteroids and controls
    public PickupManager pickupManager;

    public DiscoMode discoMode;
    // misc manager - contains alien + powerups 
    #endregion variables 


    #region init 
    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogError("This shouldn't happen !");
        }
        _instance = this;
    }

    public static GameManagerAsteroids Instance()
    {
        return _instance;
    }


    public void Init(ProfileData playerProfile)
    {
        playerManager = gameObject.AddComponent<PlayerManager>();
        asteroidManager = gameObject.AddComponent<AsteroidManager>();
        pickupManager = gameObject.AddComponent<PickupManager>();

        playerManager.Initialize();
        asteroidManager.Initialize();

        discoMode = gameObject.AddComponent<DiscoMode>();
    }

    public void Clear()
    {

    }
    #endregion init 
}
