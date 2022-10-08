using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region variables 
    public PlayerClass player;
    public PlayerControls controls;
    #endregion variables 



    #region init 
    public void Initialize()
    {
        GameObject playerObj = StateMachineAsteroids.RESOURCE_LOADER.CreateAndReturnGameObject("prefabs/Player");
        player = playerObj.GetComponent<PlayerClass>();
        player.Initialize();

        controls = gameObject.AddComponent<PlayerControls>();
        controls.Init(player);

        UpdateDifficultyAndReset();

        // ChangePlayerWeapon(1);
        ChangePlayerWeapon(2);
    }

    public void ChangePlayerWeapon(int weaponId)
    {
        switch (weaponId)
        {
            case 1:
                IWeapon newWeapon = player.gameObject.AddComponent<Weapon1>();
                player.SetupWeapon(newWeapon);
                break;

            case 2:
                IWeapon newWeapon2 = player.gameObject.AddComponent<Weapon2>();
                player.SetupWeapon(newWeapon2);
                break;
        }
    }

    public void UpdateDifficultyAndReset()
    {
        player.UpdatePlayerVariables();
    }
    #endregion init 
}
