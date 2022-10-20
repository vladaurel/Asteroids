using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pickups
{
    public class PickupExplosion : BasePickup
    {
        #region init 
        protected override void ActivateSuperPower()
        {
            AsteroidManager asteroidManager = GameManagerAsteroids.Instance().asteroidManager;
            for(int i=asteroidManager.allAsteroids.Count-1; i>-1 ; i--)
            {
                asteroidManager.allAsteroids[i].FinalizeAsteroidDestruction();
            }

            Destroy(gameObject);
        }
        #endregion init 
    }
}
