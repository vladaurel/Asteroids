using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    #region variables 
    private List<GameObject> asteroidsPrefabs = new List<GameObject>();

    [System.NonSerialized]
    public List<BaseAsteroid> allAsteroids = new List<BaseAsteroid>();

    // private float deltaTime = 0f; // time until launching a new asteroid
    private int lastQuadrant = 1; // what was the last quadrant the asteroid was launched from 


    //
    private float currentDifficulty = 0;

    // Difficulty variables 
    private float timeBetweenAsteroids;
    private float decreaseTimeForAsteroid;
    private float minTimeForAsteroid;
    private float difficulty;

    private float nextAsteroidTime;
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

        CreateNewAsteroid(2);
    }

    public void UpdateDifficultyAndReset()
    {
        ProfileData profile = StateMachineAsteroids.PLAYER_PROFILE;

        timeBetweenAsteroids = profile.initialTimeBetweenAsteroids;
        minTimeForAsteroid = profile.minTimeForAsteroid;
        difficulty = profile.difficulty;
        decreaseTimeForAsteroid = profile.deltaTime;

        minTimeForAsteroid -= (difficulty / 10);

        nextAsteroidTime = Time.time + timeBetweenAsteroids;
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
            int NQLocation = Mathf.RoundToInt(Random.Range(0, 3));
            newQuadrant = quadrants[NQLocation];
        }

        int randAsteroid = Mathf.RoundToInt(Random.Range(0, 4));
        GameObject newAsteroid = Instantiate(asteroidsPrefabs[randAsteroid]) as GameObject;

        newAsteroid.GetComponent<BaseAsteroid>().Init(newQuadrant, StateMachineAsteroids.PLAYER_PROFILE.asteroidDestroySteps, StateMachineAsteroids.PLAYER_PROFILE.initialAsteroidScale, currentDifficulty); // , currentDifficulty);

        lastQuadrant = newQuadrant;

        allAsteroids.Add(newAsteroid.GetComponent<BaseAsteroid>());


    }

    // This is the creation of the small asteroids - 
    public void CreateNewAsteroidAtLocation(Vector2 placeLocation, float angle, int stepsToDestroy, float scale)
    {
        // creates a new asteroid at location - this is generally used when the asteroid is destroyed. 
        // each new asteroid will have half the scale of the previous one 

        int randAsteroid = Mathf.RoundToInt(Random.Range(0, 4)); 
        GameObject newAsteroid = Instantiate(asteroidsPrefabs[randAsteroid]) as GameObject;
       
        newAsteroid.GetComponent<BaseAsteroid>().InitSmallAsteroid(placeLocation, angle,stepsToDestroy,scale,currentDifficulty); // , currentDifficulty);
        allAsteroids.Add( newAsteroid.GetComponent<BaseAsteroid>() );
    }
    #endregion functionality 


    #region update 
    private void Update()
    {
        if (Time.time > nextAsteroidTime)
        {
            if(timeBetweenAsteroids>minTimeForAsteroid)
            {
                timeBetweenAsteroids -= (decreaseTimeForAsteroid * difficulty);
            } else {
                timeBetweenAsteroids = minTimeForAsteroid;
            }

            nextAsteroidTime = Time.time + timeBetweenAsteroids;

            /**
            if (nextAsteroidTime< minTimeForAsteroid )
            {
                nextAsteroidTime = minTimeForAsteroid;
            }*/

            if (allAsteroids.Count < (15 + difficulty * 5))
            {
                CreateNewAsteroid();
            }
        }
    }
    #endregion update 


    #region cleanup 
    public void CleanupAsteroid(BaseAsteroid asteroidRemoved)
    {
        allAsteroids.Remove(asteroidRemoved);
    }

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
