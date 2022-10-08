using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAsteroid : MonoBehaviour
{
    #region lives 
    private int _lives = 1;

    private int _steps;
    #endregion lives 


    #region init 
    public void Init(int quadrant, int steps, float difficulty )
    {
        _steps = steps;
    }

    public void Init()
    {
        
    }
    #endregion init 
}
