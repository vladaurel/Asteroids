using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupExtraLife : BasePickup
{
    protected override void ActivateSuperPower()
    {
        StateMachineAsteroids.Instance().uiManager.lifeHandler.IncreaseLives(); 
    }
}
