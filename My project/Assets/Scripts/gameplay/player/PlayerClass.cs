using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Powerups;

public class PlayerClass : MonoBehaviour
{
    #region variables 
    private float _rotationSpeed;
    private float _accelerationSpeed;

    private IWeapon _weapon = null; // strategy pattern 

    // physics 
    private Rigidbody2D _body;

    // bounds 
    private float orthographicWidth;
    private float orthographicHeight;

    // powers - would usually place these in a different class, in an array list, following a powers interface - 
    // no time for this. 
    public bool hasShield = false;
    public bool hasFriend = false;
    private float _invulnerabilityTime = 0;
    #endregion variables 

    #region init 
    public void Initialize()
    {
        _body = gameObject.GetComponent<Rigidbody2D>();

        orthographicWidth = Camera.main.orthographicSize * Camera.main.aspect;
        orthographicHeight = orthographicWidth / Camera.main.aspect;

        UpdatePlayerVariables();
    }

    public void SetupWeapon(IWeapon newWeapon)
    {
        if(_weapon != null)
        {
            _weapon.Remove();
        }
        _weapon = newWeapon;
    }
    #endregion init 


    #region functionality 
    public void UpdatePlayerVariables()
    {
        ProfileData profile = StateMachineAsteroids.PLAYER_PROFILE;
        _rotationSpeed = profile.rotationSpeed;
        _accelerationSpeed = profile.acceleration;

        _rotationSpeed = 80;
        _accelerationSpeed = 200;

        gameObject.GetComponent<TrailRenderer>().enabled = profile.spaceshipTrail;
    }

    public void ChangeWeapon(IWeapon newWeapon)
    {
        _weapon = newWeapon;
    }

    public void Move(bool left, bool right, bool up, bool down)
    {

        if(left)        {
            // Quaternion deltaRotation = Quaternion.Euler( new Vector3(0,100,0) * Time.fixedDeltaTime);
            // _body.MoveRotation(_body.ro * deltaRotation);

            _body.rotation += _rotationSpeed * Time.deltaTime;
        } else {
            if(right)
            {
                _body.rotation -= _rotationSpeed * Time.deltaTime;
            } else {
                // it already has a decrease 
            }
        }

        float angle = _body.rotation;
        angle = (angle % 360);// *Mathf.Rad2Deg;
        Vector2 direction = new Vector2(Mathf.Cos(angle),-Mathf.Sin(angle));

        if(up)
        {
            _body.AddForce(transform.right * _accelerationSpeed * Time.deltaTime);
        } else {
            if(down)
            {
                _body.AddForce(-transform.right * _accelerationSpeed * Time.deltaTime);
            } else {
                // it already has a decrease - this is setup in WYSIWYG 
            }
        }
        // if( Mathf.Sqrt( Mathf.Pow(_body.velocity.x)
    }

    public void UpdateAttack(bool fire)
    {
        if(fire)
        {
            _weapon.Fire();
        }
    }
    #endregion functionality 


    #region update 
    private void Update()
    {
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


    #region collision 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(StateMachineAsteroids.PLAYER_PROFILE.footbalMode)
        {
            return;
        }

        if (Time.time > _invulnerabilityTime)
        {
            if (collision.collider.gameObject.layer == 7)
            {
                Debug.LogError("Received hit");
                if (hasShield)
                {
                    // remove the shield 
                    hasShield = false;
                    ShieldPowerup shield = gameObject.GetComponentInChildren<ShieldPowerup>();
                    if (shield != null)
                    {
                        Destroy(shield.gameObject);
                    }
                } else { 
                    // reset the speeds 
                    _body.velocity = new Vector2(0, 0);
                    _body.angularVelocity = 0f;

                    StateMachineAsteroids.Instance().uiManager.lifeHandler.DecreaseLife();
                }
            } else {
                _body.angularVelocity = 0f;
            }
        } else {
            _invulnerabilityTime = Time.time + 3;
        }
    }

    public void SetNewInvulnTime(float newTime)
    {
        if(newTime > _invulnerabilityTime)
        {
            _invulnerabilityTime = newTime;
        }
    }
    #endregion collision 
}
