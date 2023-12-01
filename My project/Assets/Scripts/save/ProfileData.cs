/**
 * All of the profiles will look like this one.
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ProfileData {
    public string playerName = "default";

    public float initialTimeBetweenAsteroids = 2.2f; // the initial time it takes for an asteroid to appear
    public float deltaTime = 0.1f; // what is the time difference 
    public float minTimeForAsteroid = 1f; // 

    public int currentLives = 10; 
    public int score = 0; 


    //============================================================
    //                 Designer Options : 
    //============================================================
    public int hpMaxLives = 6;
    public float acceleration = 200.0f;
    public float rotationSpeed = 80.0f;
    public float initialAsteroidScale = 2.0f;
    public int asteroidDestroySteps = 4; // how many times will it break into others ? 
    public float difficulty = 1f; // 

    public bool playIntro = true;

    public int weaponId = 1; // what weapon does the player have equipped ? 

    //============================================================
    //               Extra options : 
    //============================================================
    public bool pickupsMoveToPlayer = true;
    public int chanceToCreatePickup = 3;
    

    //============================================================
    //               Modes : 
    //============================================================
    // public bool defenderShip = false; // creates a ship that will spin around the player - // ran out of time :P 
    public bool spaceshipTrail = false; // your ship will leave a trail behind
    public bool footbalMode = false; // asteroids are destroyed when leaving the screen. Player cannot die. 
    public bool alliedVisitors = false; // random ships will start appearing and shooting at the asteroids 
    public bool discoMode = false; // asteroids will change colors every now and then - 

    //============================================================
    //              Powerups : 
    //============================================================
    public List<int> powerupsAllowed = new List<int>() { 1,2 };  // 4 later - 
    // 1-shield ; 2-weapon 2 ; 3-asteroid bomb ;
    // 4 - defensive ball ; 5 - extra lives ; 6 - ethereal ; // ran out of time 


    //============================================================
    //           Keyboard options follow 
    //============================================================
    public KeyCode left = KeyCode.LeftArrow;  // A
    public KeyCode right = KeyCode.RightArrow;  // D
    public KeyCode up = KeyCode.UpArrow;  // W
    public KeyCode down = KeyCode.DownArrow;  // S
    public KeyCode attack = KeyCode.Space; 
    // public KeyCode openInventory = KeyCode.I; 

    public KeyCode special1 = KeyCode.Alpha1; 
    public KeyCode special2 = KeyCode.Alpha2; 
    public KeyCode special3 = KeyCode.Alpha3; 
    public KeyCode special4 = KeyCode.Alpha4;

    //=====================================================================================================
    //            GENERAL PLAYER PREFERENCES FOLLOW 
    //=====================================================================================================
    public string currentLanguage = "en"; // Language currently used by the game 


    #region functionality 
    public void PrepareForSave()
    {
        // TODO 
        // actually not really needed but just in case I want to save everything in the moment 
        // and need to get data from the player in the future - this is a reminder. 
    }

    public void AddPowerup(string powerup)
    {
        int valueToCheck = 1;
        switch (powerup)
        {
            case "shield": valueToCheck = 1; break;
            case "weapon2": valueToCheck = 2; break;
            case "asteroidBomb": valueToCheck = 3; break;
            case "defensiveBall": valueToCheck = 4; break;
            case "extraLives": valueToCheck = 5; break;
            case "ethereal": valueToCheck = 6; break;
        }
        if(!powerupsAllowed.Contains(valueToCheck))
        {
            powerupsAllowed.Add(valueToCheck);
        }
    }

    public void RemovePowerup(string powerup)
    {
        int valueToCheck = 0;
        switch (powerup)
        {
            case "shield": valueToCheck = 1; break;
            case "weapon2": valueToCheck = 2; break;
            case "asteroidBomb": valueToCheck = 3; break;
            case "defensiveBall": valueToCheck = 4; break;
            case "extraLives": valueToCheck = 5; break;
            case "ethereal": valueToCheck = 6; break;
        }
        if(powerupsAllowed.Contains(valueToCheck))
        {
            powerupsAllowed.Remove(valueToCheck);
        }
    }
    #endregion functionality 
}
