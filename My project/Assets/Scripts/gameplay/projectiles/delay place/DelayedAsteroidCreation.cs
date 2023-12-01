/**
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedAsteroidCreation : MonoBehaviour
{
    #region variables 
    private Vector2 _location;
    private float _angle;
    private int _stepsToDestroy;
    private float _scale;
    private float _timeLeft;
    #endregion variables 

    #region init 
    public void Initialize(Vector2 placeLocation, float angleIs, int stepsToDestroyAre, float scaleIs, float timeToIt)
    {
        Debug.Log("Initialize gets called " + scaleIs);
        _location = placeLocation;
        _angle = angleIs;
        _stepsToDestroy = stepsToDestroyAre;
        _scale = scaleIs;
        _timeLeft = timeToIt;
    }
    #endregion init 

    #region update 
    private void FixedUpdate()
    {
        if(Time.time>_timeLeft)
        {
            GameManagerAsteroids.Instance().asteroidManager.CreateNewAsteroidAtLocation(_location, _angle, _stepsToDestroy, _scale);
            Destroy(this);
        }
    }
    #endregion update 
}
