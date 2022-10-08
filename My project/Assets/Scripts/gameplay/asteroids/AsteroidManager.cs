using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    #region variables 
    private List<GameObject> asteroidsPrefabs = new List<GameObject>();

    [System.NonSerialized]
    public List<BaseAsteroid> allAsteroids = new List<BaseAsteroid>();

    private float deltaTime = 0f; // time until launching a new asteroid
    private int lastQuadrant = 1; // what was the last quadrant the asteroid was launched from 


    //
    private float currentDifficulty = 0;

    // Difficulty variables 
    private float timeForAsteroid;
    private float minTimeForAsteroid;
    private float difficultyIncrease;
    #endregion variables 


    #region init 
    private void Awake()
    {
        GameObject tempAsteroid = StateMachineAsteroids.RESOURCE_LOADER.ReturnPrefab("prefabs/Asteroid1");
        asteroidsPrefabs.Add(tempAsteroid);
        tempAsteroid = StateMachineAsteroids.RESOURCE_LOADER.ReturnPrefab("prefabs/Asteroid2");
        asteroidsPrefabs.Add(tempAsteroid);
        tempAsteroid = StateMachineAsteroids.RESOURCE_LOADER.ReturnPrefab("prefabs/Asteroid3");
        asteroidsPrefabs.Add(tempAsteroid);
        tempAsteroid = StateMachineAsteroids.RESOURCE_LOADER.ReturnPrefab("prefabs/Asteroid4");
        asteroidsPrefabs.Add(tempAsteroid);
        tempAsteroid = StateMachineAsteroids.RESOURCE_LOADER.ReturnPrefab("prefabs/Asteroid5");
        asteroidsPrefabs.Add(tempAsteroid);
    }

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
            int NQLocation = Mathf.RoundToInt(Random.Range(0, 2));
            newQuadrant = quadrants[NQLocation];
        }


        int randAsteroid = Random.RandomRange(0, 4);
        GameObject newAsteroid = Instantiate(asteroidsPrefabs[randAsteroid]) as GameObject;

        newAsteroid.GetComponent<BaseAsteroid>().Init(newQuadrant, StateMachineAsteroids.PLAYER_PROFILE.destroySteps, currentDifficulty);
    }

    public void CreateNewAsteroidAtLocation(Vector2 placeLocation, Vector2 direction, int stepsToDestroy, int newQuadrant =-1)
    {

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
