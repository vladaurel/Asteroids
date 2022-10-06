using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    #region variables 
    [System.NonSerialized]
    public List<BaseAsteroid> allAsteroids = new List<BaseAsteroid>();

    
    private float deltaTime = 0f; // time until launching a new asteroid
    private int lastQuadrant = 1; // what was the last quadrant the asteroid was launched from 
    #endregion variables 


    #region init 
    public void Initialize()
    {
        UpdateDifficultyAndReset();
    }

    public void UpdateDifficultyAndReset()
    {
        ProfileData playerProfile = StateMachineAsteroids.PLAYER_PROFILE;
    }
    #endregion init 


    #region functionality 
    public void CreateNewAsteroid(int newQuadrant = -1)
    {
        if(newQuadrant < 0)
        {
            List<int> quadrants = new List<int>() { 1, 2, 3, 4 };
            if(quadrants.Contains(lastQuadrant))
            {
                quadrants.Remove(lastQuadrant);
            }
        }
        
    }
    #endregion functionality 


    #region cleanup 
    public void CleanUp()
    {
        for(int i=(allAsteroids.Count-1);i>-1;i--)
        {
            Destroy(allAsteroids[i]);
        }
        allAsteroids.Clear();
    }
    #endregion cleanup
}
