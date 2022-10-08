using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour, IWeapon
{
    #region variables 
    private float _cooldown = 0.75f;
    private float _nextFire = 0f;
    #endregion variables 



    #region functionalities 
    public virtual void Fire()
    {
        if(_nextFire<Time.time)
        {
            _nextFire = Time.time + _cooldown;
            UseWeapon();
        }
    }

    public virtual void UseWeapon()
    {
        // written for the purpose of overriding 
    }

    public void Remove()
    {
        Destroy(this);
    }

    public virtual void SetupCooldown(float newCooldown)
    {
        _cooldown = newCooldown;
    }
    #endregion functionalities 
}
