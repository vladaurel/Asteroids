/**
 * Would usually do this with a coroutine but in a rush :) 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    #region variables 
    private float _timeToLive = 3f;

    protected int _hits = 1;
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
            Destroy(gameObject);
        }
    }
    #endregion

    #region collision 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer != gameObject.layer)
        {
            _hits--;
            if(_hits<=0)
            {
                // Destroy(this);
                Destroy(gameObject);
            }
        }
    }
    #endregion collision 
}
