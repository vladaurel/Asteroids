using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    #region variables 
    private float rotationSpeed;
    private float accelerationSpeed;

    private IWeapon weapon = null;

    private int health;

    // physics 
    private Rigidbody2D _body;
    #endregion variables 

    #region init 
    public void Initialize()
    {
        _body = gameObject.GetComponent<Rigidbody2D>();
        UpdatePlayerVariables();
    }

    public void SetupWeapon(IWeapon newWeapon)
    {
        if(weapon != null)
        {
            weapon.Remove();
        }
        weapon = newWeapon;
    }
    #endregion init 


    #region functionality 
    public void UpdatePlayerVariables()
    {
        ProfileData profile = StateMachineAsteroids.PLAYER_PROFILE;
        rotationSpeed = profile.rotationSpeed;
        accelerationSpeed = profile.acceleration;

        rotationSpeed = 80;
        accelerationSpeed = 200;

        health = profile.hpMaxLives;
    }

    public void ChangeWeapon(IWeapon newWeapon)
    {
        weapon = newWeapon;
    }

    public void Move(bool left, bool right, bool up, bool down)
    {

        if(left)        {
            // Quaternion deltaRotation = Quaternion.Euler( new Vector3(0,100,0) * Time.fixedDeltaTime);
            // _body.MoveRotation(_body.ro * deltaRotation);

            _body.rotation += rotationSpeed * Time.deltaTime;
        } else {
            if(right)
            {
                _body.rotation -= rotationSpeed * Time.deltaTime;
            } else {
                // it already has a decrease 
            }
        }

        float angle = _body.rotation;
        angle = (angle % 360);// *Mathf.Rad2Deg;
        Vector2 direction = new Vector2(Mathf.Cos(angle),-Mathf.Sin(angle));

        if(up)
        {
            _body.AddForce(transform.right * accelerationSpeed * Time.deltaTime);
        } else {
            if(down)
            {
                _body.AddForce(-transform.right * accelerationSpeed * Time.deltaTime);
            } else {
                // it already has a decrease 
            }
        }
        // if( Mathf.Sqrt( Mathf.Pow(_body.velocity.x)
    }

    public void UpdateAttack(bool fire)
    {
        if(fire)
        {
            weapon.Fire();
        }
    }
    #endregion functionality 


    #region update 
    private void Update()
    {
        float orthographicWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float orthographicHeight = orthographicWidth / Camera.main.aspect;

        if (transform.position.x< (-orthographicWidth))
        {
            transform.position = new Vector2(orthographicWidth  - 0.05f, transform.position.y);
        } else {
            if(transform.position.x > (orthographicWidth ))
            {
                transform.position = new Vector2(-orthographicWidth +0.05f, transform.position.y);
            }
        }

        if (transform.position.y < -orthographicHeight)
        {
            transform.position = new Vector2(transform.position.x, orthographicHeight - 0.05f);
        } else {
            if (transform.position.y > orthographicHeight)
            {
                transform.position = new Vector2(transform.position.x, -orthographicHeight + 0.05f);
            }
        }
    }
    #endregion update 
}
