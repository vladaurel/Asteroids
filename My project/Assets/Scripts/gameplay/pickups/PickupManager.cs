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

    public async void ChanceToAddPowerup(Vector2 atPosition)
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

            /**
            Debug.LogError(_profile.powerupsAllowed[location]+"| POWERUP FOR LOCATION. |"+location);
            for(int i=0;i<_profile.powerupsAllowed.Count;i++)
            {
                Debug.Log(_profile.powerupsAllowed[i]+"| Profile & powerups allowed |||||"+i);
            }
            */

            switch (_profile.powerupsAllowed[location]) 
            { 
                case 1: pickup = await res.CreateAndReturnGameObject("pickups/PickupShield_Prf"); break; 
                case 2: pickup = await res.CreateAndReturnGameObject("pickups/PickupWeapon2_Prf"); break; 
                case 3: pickup = await res.CreateAndReturnGameObject("pickups/PickupAsteroidExplosion_Prf"); break; 
                case 4: pickup = await res.CreateAndReturnGameObject("pickups/PickupDefensiveFriend_Prf"); break; 
                case 5: pickup = await res.CreateAndReturnGameObject("pickups/PickupExtraLife_Prf"); break; 
                case 6: pickup = await res.CreateAndReturnGameObject("pickups/PickupEthereal_Prf"); break; 
            }
            pickup.transform.position = atPosition;
        }
        
    }
}
