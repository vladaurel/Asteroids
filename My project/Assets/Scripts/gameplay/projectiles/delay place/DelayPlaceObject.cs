using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayPlaceObject : MonoBehaviour
{
    #region variables 
    private Vector2 _finalPosition;
    private float _timeToPos;
    #endregion variables 


    #region initialize 
    public void Init(Vector2 finalPosition, float time)
    {
        _finalPosition = finalPosition;
        _timeToPos = time;
    }
    #endregion initialize 


    #region update
    public void FixedUpdate()
    {
        if(Time.time> _timeToPos)
        {
            transform.position = _finalPosition;
            Destroy(this);
        }
    }
    #endregion update 
}
