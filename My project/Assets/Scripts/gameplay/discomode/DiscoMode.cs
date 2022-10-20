using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoMode : MonoBehaviour
{
    #region variables 
    private float _deltaTime = 1f;
    private float _nextTime = 0.5f;
    #endregion variables 

    #region init 
    private void Start()
    {
        UpdateDiscoOnOff();
    }

    public void UpdateDiscoOnOff()
    {
        if(!StateMachineAsteroids.PLAYER_PROFILE.discoMode)
        {
            enabled = false;
        } else {
            enabled = true;
        }
    }
    #endregion init 


    #region functionality 
    private void ColorAllAsteroids()
    {
        List<BaseAsteroid> asteroids = GameManagerAsteroids.Instance().asteroidManager.allAsteroids;

        for(int i=0;i<asteroids.Count;i++)
        {
            Color randomColor = new Color( ReturnRandomNumber(), ReturnRandomNumber(), ReturnRandomNumber() );
            asteroids[i].GetComponent<SpriteRenderer>().color = randomColor;
        }
    }

    private float ReturnRandomNumber()
    {
        return Random.Range(0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > _nextTime)
        {
            _nextTime = Time.time + _deltaTime;
            ColorAllAsteroids();
        }
    }
    #endregion functionality 
}
