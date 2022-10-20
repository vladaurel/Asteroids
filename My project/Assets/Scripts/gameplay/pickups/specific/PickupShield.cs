using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Powerups;

namespace Pickups
{
    public class PickupShield : BasePickup
    {
        protected override void ActivateSuperPower()
        {
            PlayerClass player = GameManagerAsteroids.Instance().playerManager.player;

            // base.ActivateSuperPower();
            if (!player.hasShield)
            {
                // player.gameObject.AddComponent<ShieldPowerup>();
                GameObject shield = StateMachineAsteroids.RESOURCE_LOADER.CreateAndReturnGameObject("powerup/ShieldPowerup");
                
                shield.transform.parent = player.transform;
                shield.transform.position = player.transform.position;
                player.hasShield = true;
            }
        }
    }
}
