/**
 * Would usually do this with a coroutine but in a rush :) 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    #region variables 
    private float _timeToLive = 1.5f;
    #endregion variables 


    #region init 
    private void Awake()
    {
        _timeToLive += Time.time;
    }
    #endregion init 

    #region 
    // Update is called once per frame
    void Update()
    {
        if(Time.time>_timeToLive)
        {
            Destroy(this);
        }
    }
    #endregion 
}
