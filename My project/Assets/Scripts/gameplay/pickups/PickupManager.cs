using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    #region variables 
    private ProfileData _profile;
    #endregion variables 

    private void Start()
    {
        _profile = StateMachineAsteroids.PLAYER_PROFILE;
    }

    public void ChanceToAddPowerup(Vector2 atPosition)
    {
        if(StateMachineAsteroids.PLAYER_PROFILE.footbalMode)
        {
            Debug.LogError("Shouldn't reach this spot !");
            return;
        }

        // if(true)
        if (Random.Range(0,10) <= _profile.chanceToCreatePickup) 
        {
            int location = Random.Range(0, _profile.powerupsAllowed.Count); 
            ResourcesLoader res = StateMachineAsteroids.RESOURCE_LOADER; 

            GameObject pickup = null;

            switch (_profile.powerupsAllowed[location]) 
            { 
                case 1: pickup = res.CreateAndReturnGameObject("pickups/PickupShield"); break; 
                case 2: pickup = res.CreateAndReturnGameObject("pickups/PickupWeapon2"); break; 
                case 3: pickup = res.CreateAndReturnGameObject("pickups/PickupAsteroidExplosion"); break; 
                case 4: pickup = res.CreateAndReturnGameObject("pickups/PickupDefensiveFriend"); break; 
                case 5: pickup = res.CreateAndReturnGameObject("pickups/PickupExtraLife"); break; 
                case 6: pickup = res.CreateAndReturnGameObject("pickups/PickupEthereal"); break; 
            }
            pickup.transform.position = atPosition;
        }
        
    }
}
