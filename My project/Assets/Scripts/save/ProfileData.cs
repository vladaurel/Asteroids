/**
 * All of the profiles will look like this one.
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ProfileData {
    public string playerName = "default";

    public float acceleration = 20.0f;
    public float rotationSpeed = 20.0f;
    public int hpMaxLives = 3;

    public int difficultyIncrease = 1; // max is 10 
    public int destroySteps = 1; // how many times will it break into others ? 
    public int powerUpChance = 2; // 2/10

    public List<int> powerupsAllowed = new List<int>() { 1, 2 }; // all the way to 5...

    public int weaponId = 1; // what weapon does the player have equipped ? 

    //============================================================
    //           Keyboard options follow 
    //============================================================
    public KeyCode left = KeyCode.A; 
    public KeyCode right = KeyCode.D; 
    public KeyCode up = KeyCode.W; 
    public KeyCode down = KeyCode.S; 
    public KeyCode attack = KeyCode.Space; 
    public KeyCode openInventory = KeyCode.I; 

    public KeyCode jump = KeyCode.Space;

    public KeyCode special1 = KeyCode.Alpha1; 
    public KeyCode special2 = KeyCode.Alpha2; 
    public KeyCode special3 = KeyCode.Alpha3; 
    public KeyCode special4 = KeyCode.Alpha4;

    public KeyCode pickup = KeyCode.E;

    public KeyCode buildingModeforceGrid = KeyCode.LeftShift;
    public KeyCode rotateObjectKey = KeyCode.R;

    //=====================================================================================================
    //            GENERAL PLAYER PREFERENCES FOLLOW 
    //=====================================================================================================
    public string currentLanguage = "en"; // Language currently used by the game 


    #region functionality 
    public void PrepareForSave()
    {
        // UPDATE THE GENERAL EVENTS ! also update : time of day, player levels, etc. 
        // TODO 
        Debug.Log("Prepares everything for the save.");
    }
    #endregion functionality 
}
