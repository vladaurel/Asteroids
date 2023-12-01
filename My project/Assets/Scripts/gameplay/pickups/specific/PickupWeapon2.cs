using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pickups
{
    public class PickupWeapon2 : BasePickup
    {
        protected override void ActivateSuperPower()
        {
            // base.ActivateSuperPower(); 
            GameManagerAsteroids.Instance().playerManager.ChangePlayerWeapon(2);
            base.ActivateSuperPower();
        }
    }
}
