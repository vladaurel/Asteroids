using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PowerupsMenu : UIBaseMenu
{
    #region variables 
    // Intro on/off - 
    [SerializeField]
    private Toggle _playIntro;

    // Modes 
    [SerializeField]
    private Toggle _footbalMode;
    [SerializeField]
    private Toggle _discoMode;
    [SerializeField]
    private Toggle _visitors;
    [SerializeField]
    private Toggle _spaceShipTrail;

    // Powerups 
    [SerializeField]
    private Toggle _powerupShield;
    [SerializeField]
    private Toggle _powerupWeapon2;
    [SerializeField]
    private Toggle _powerupAsteroidBomb;
    [SerializeField]
    private Toggle _powerupDefensiveBall;
    [SerializeField]
    private Toggle _powerupExtraLives;
    [SerializeField]
    private Toggle _powerupEthereal;

    // Homing - 
    [SerializeField]
    private Toggle _homingPowerups;
    #endregion variables 


    #region apply and reset
    private void Awake()
    {
        ProfileData profile = StateMachineAsteroids.PLAYER_PROFILE;

        if(profile.playIntro) { _playIntro.isOn = true;  } else { _playIntro.isOn = false; };
        if (profile.pickupsMoveToPlayer) { _homingPowerups.isOn = true; } else { _homingPowerups.isOn = false; };

        if (profile.footbalMode) { _footbalMode.isOn = true; };
        if (profile.discoMode ) {_discoMode.isOn = true;} else { _discoMode.isOn = false; };
        if (profile.alliedVisitors) { _visitors.isOn = true; } else { _visitors.isOn = false; };
        if (profile.spaceshipTrail) { _spaceShipTrail.isOn = true; } else { _spaceShipTrail.isOn = false; }

        if (profile.powerupsAllowed.Contains(1)) { _powerupShield.isOn = true; } else { _powerupShield.isOn = false; }
        if (profile.powerupsAllowed.Contains(2)) { _powerupWeapon2.isOn = true; } else { _powerupWeapon2.isOn = false; }
        if (profile.powerupsAllowed.Contains(3)) { _powerupAsteroidBomb.isOn = true; } else { _powerupAsteroidBomb.isOn = false; }
        if (profile.powerupsAllowed.Contains(4)) { _powerupDefensiveBall.isOn = true; } else { _powerupDefensiveBall.isOn = false; }
        if (profile.powerupsAllowed.Contains(5)) { _powerupExtraLives.isOn = true; } else { _powerupExtraLives.isOn = false; }
        if (profile.powerupsAllowed.Contains(6)) { _powerupEthereal.isOn = true; } else { _powerupEthereal.isOn = false; }
    }

    public void ApplyAndReset()
    {
        ProfileData profile = StateMachineAsteroids.PLAYER_PROFILE;
        
        profile.pickupsMoveToPlayer = _homingPowerups.isOn;
        profile.playIntro = _playIntro.isOn;

        // modes
        profile.footbalMode = _footbalMode.isOn;
        profile.discoMode = _discoMode.isOn;
        profile.alliedVisitors = _visitors.isOn;
        profile.spaceshipTrail = _spaceShipTrail.isOn;

        // powerups 
        if (_powerupShield.isOn) { profile.AddPowerup("shield"); } else { profile.RemovePowerup("shield"); }
        if (_powerupWeapon2.isOn) { profile.AddPowerup("weapon2"); } else { profile.RemovePowerup("weapon2"); }
        if (_powerupAsteroidBomb.isOn) { profile.AddPowerup("asteroidBomb"); } else { profile.RemovePowerup("asteroidBomb"); }
        if (_powerupDefensiveBall.isOn) { profile.AddPowerup("defensiveBall"); } else { profile.RemovePowerup("defensiveBall"); }
        if (_powerupExtraLives.isOn) { profile.AddPowerup("extraLives"); } else { profile.RemovePowerup("extraLives"); }
        if (_powerupEthereal.isOn) { profile.AddPowerup("ethereal"); } else { profile.RemovePowerup("ethereal"); }

        StateMachineAsteroids.Instance().SaveGame();
        Time.timeScale = 1f;

        if (_playIntro.isOn)
        {
            SceneManager.LoadScene(0);
        } else {
            SceneManager.LoadScene(1);
        }
    }
    #endregion apply and reset 
}
