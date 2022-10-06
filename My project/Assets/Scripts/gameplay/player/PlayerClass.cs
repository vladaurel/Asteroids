using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    #region variables 
    private float rotationSpeed;
    private float accelerationSpeed;

    private IWeapon weapon;

    private int health;

    // physics 
    private Rigidbody2D _body;
    #endregion variables 

    #region init 
    public void Initialize()
    {
        _body = gameObject.GetComponent<Rigidbody2D>();
        ChangeMovementVariables();
    }
    #endregion init 


    #region functionality 
    public void ChangeMovementVariables()
    {
        ProfileData profile = StateMachineAsteroids.PLAYER_PROFILE;
        rotationSpeed = profile.rotationSpeed;
        accelerationSpeed = profile.acceleration;
        health = profile.hpMaxLives;
    }

    public void ChangeWeapon(IWeapon newWeapon)
    {
        weapon = newWeapon;
    }

    public void Move(bool left, bool right, bool up, bool down)
    {

    }

    public void UpdateAttack(bool fire)
    {
        if(fire)
        {
            weapon.Fire();
        }
    }
    #endregion functionality 
}
