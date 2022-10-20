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

    [SerializeField]
    private int projectileType = 1;
    #endregion variables 


    #region init 
    private void OnEnable()
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
            // GameManagerAsteroids.Instance().projectilesPool.SetProjectileIntoPool(gameObject, _projectileType);
            SetIntoPool();
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
                SetIntoPool();
            }
        }
    }
    #endregion collision 

    #region pooling 
    public void SetIntoPool()
    {
        gameObject.SetActive(false);
        GameManagerAsteroids.Instance().projectilesPool.SetProjectileIntoPool(gameObject, projectileType);
    }

    public virtual void ReadyForReuse()
    {
        _hits = 1;
        Rigidbody2D tempBody = gameObject.GetComponent<Rigidbody2D>();
        tempBody.angularVelocity = 0;
        tempBody.velocity = new Vector2(0, 0);
        gameObject.SetActive(true);
    }
    #endregion pooling 
}
