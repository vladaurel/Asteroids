using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : BaseWeapon
{
    #region variables 
    // private GameObject _projectile;

    private float weaponTime;
    #endregion variables 

    #region init 
    private void Awake()
    {
        // _projectile = GameManagerAsteroids.Instance().projectilesPool.ReturnProjectileType(2);
        // _projectile.SetActive(false);

        weaponTime = Time.time + 10f;

        SetupCooldown(0.33f);
    }
    #endregion init 

    #region functionality 
    public override void UseWeapon()
    {
        StateMachineAsteroids.Instance().audioController.PlayAudio("bullet2");

        GameObject newBullet = GameManagerAsteroids.Instance().projectilesPool.ReturnProjectileType(2);
        newBullet.transform.position = transform.position;

        Rigidbody2D body = newBullet.GetComponent<Rigidbody2D>();
        body.rotation = gameObject.GetComponent<Rigidbody2D>().rotation; // + deltaAngle;

        body.AddForce(transform.right * 330 );
    }
    #endregion functionality 



    #region update 
    private void Update()
    {
        if(Time.time > weaponTime)
        {
            this.enabled = false;

            GameManagerAsteroids.Instance().playerManager.ChangePlayerWeapon(1);

            Remove();
        }
    }
    #endregion update 
}
