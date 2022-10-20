/**
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePickup : MonoBehaviour
{
    #region variables 
    #endregion variables 

    #region init 
    private void Awake()
    {
        if(StateMachineAsteroids.PLAYER_PROFILE.pickupsMoveToPlayer)
        {
            gameObject.AddComponent<MoveTowardsPlayer>();
        }
    }
    #endregion init 


    #region specific functionality 
    // private void OnCollisionEnter2D(Collision2D collision)
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // this can only collide with the player - however it can also collide with other ghost parts
        if(collider.gameObject.GetComponent<PlayerClass>()!=null)
        {
            ActivateSuperPower();

            if(gameObject.GetComponent<MoveTowardsPlayer>() != null)
            {
                gameObject.GetComponent<MoveTowardsPlayer>().enabled = false;
            }
            enabled = false;
            Destroy(gameObject);
        }
    }

    protected virtual void ActivateSuperPower()
    {
        Debug.Break();
    }
    #endregion specific functionality 


    #region general functionality 
    #endregion general functionality 
}
