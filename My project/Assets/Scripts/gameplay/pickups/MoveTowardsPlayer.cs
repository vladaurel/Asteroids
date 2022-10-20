/**
 * Move this towards the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    #region variables 
    private GameObject _player;
    private Rigidbody2D _body;
    private float _velocity = 3f;
    #endregion variables 

    #region init 
    private void Awake()
    {
        _player = GameManagerAsteroids.Instance().playerManager.player.gameObject;
        _body = gameObject.GetComponent<Rigidbody2D>();
    }
    #endregion init 


    #region update
    private void Update()
    {
        float angle = Mathf.Atan2(_player.transform.position.y - transform.position.y, _player.transform.position.x - transform.position.x);
        _body.velocity = new Vector2(Mathf.Cos(angle) * _velocity, Mathf.Sin(angle) * _velocity);
    }
    #endregion update 
}
