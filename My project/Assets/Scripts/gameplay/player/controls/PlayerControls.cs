/**
 * Handles all controls for the player 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    #region variables 
    // required 
    private PlayerClass player;
    private bool _locked = false;

    // booleans for controls 
    private bool _left;
    private bool _right;
    private bool _down;
    private bool _up;
    private bool _fire;


    // KEYS 
    private KeyCode _leftKey;
    private KeyCode _rightKey;
    private KeyCode _upKey;
    private KeyCode _downKey;
    private KeyCode _fireKey;
    #endregion variables 




    #region init and reset 
    public void Init(PlayerClass playerIs)
    {
        player = playerIs;
        SetupControls();
    }

    public void SetupControls()
    {
        ProfileData profile = StateMachineAsteroids.PLAYER_PROFILE;

        _leftKey = profile.left;
        _rightKey = profile.right;
        _upKey = profile.up;
        _downKey = profile.down;
        _fireKey = profile.attack;
    }

    #endregion init and reset 



    #region lock unlock
    public void Lock(bool lockIt)
    {
        _locked = lockIt;
    }
    #endregion lock unlock 

    #region keyboard functionality 

    // would normally do this with Task - time constraints ( inefficient as we're placing it in update ) 
    private void Update()
    {
        _left = Input.GetKey(_leftKey);
        _right = Input.GetKey(_rightKey);
        _up = Input.GetKey(_upKey);
        _down = Input.GetKey(_downKey);
        _fire = Input.GetKey(_fireKey);
    }

    private void FixedUpdate()
    {
        if(!_locked)
        {
            player.Move(_left,_right,_up,_down);
            player.UpdateAttack(_fire);
        }
    }
    #endregion keyboard functionality 
}
