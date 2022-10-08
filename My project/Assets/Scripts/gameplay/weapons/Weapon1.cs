using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : BaseWeapon
{
    #region variables 
    private GameObject _projectile;
    #endregion variables 

    #region init 
    private void Awake()
    {
        _projectile = StateMachineAsteroids.RESOURCE_LOADER.ReturnPrefab("prefabs/BasicProjectile");
    }
    #endregion init 


    #region use weapon 
    public override void UseWeapon()
    {
        // create 3 projectiles 
        // send them at 3 angles 

        Debug.Log("Using weapon !");

        CreateBullet(-30);
        CreateBullet(0);
        CreateBullet(30);
    }

    private void CreateBullet(float deltaSpeed)
    {
        GameObject newBullet = Instantiate(_projectile);
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
