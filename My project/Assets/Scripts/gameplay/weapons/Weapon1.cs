using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : BaseWeapon
{
    #region variables 
    // private GameObject _projectile;
    #endregion variables 

    #region init 
    private void Start()
    {
       // _projectile = GameManagerAsteroids.Instance().projectilesPool.ReturnProjectileType(1);
    }
    #endregion init 


    #region use weapon 
    public override void UseWeapon()
    {
        StateMachineAsteroids.Instance().audioController.PlayAudio("bullet1");

        // create 3 projectiles 
        // send them at 3 angles 
        CreateBullet(-30);
        CreateBullet(0);
        CreateBullet(30);
    }

    private async void CreateBullet(float deltaSpeed)
    {
        // GameObject newBullet = Instantiate(_projectile);
        GameObject newBullet = await GameManagerAsteroids.Instance().projectilesPool.ReturnProjectileType(1);
        newBullet.transform.position = transform.position;

        // newBullet.transform.position = newBullet.transform.position + (0.5f * new Vector3(Mathf.Cos(gameObject.transform.eulerAngles.z), Mathf.Sin(gameObject.transform.eulerAngles.z), 0));

        Rigidbody2D body = newBullet.GetComponent<Rigidbody2D>();
        body.rotation = gameObject.GetComponent<Rigidbody2D>().rotation;// + deltaAngle;

        // body.rotation += deltaAngle;
        // Debug.LogError(body.rotation+"|"+deltaAngle);
        // newBullet.GetComponent<Rigidbody2D>().velocity = newBullet.transform.forward * 2000;

        body.AddForce(transform.right * (300 + deltaSpeed));
    }
    #endregion use weapon 
}
