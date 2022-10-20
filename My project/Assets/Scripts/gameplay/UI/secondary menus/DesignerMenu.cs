using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DesignerMenu : UIBaseMenu
{
    #region setups 
    // private bool 
    [SerializeField]
    private InputField _accelNumber;
    [SerializeField]
    private InputField _rotation;
    [SerializeField]
    private InputField _maxHealth;

    [SerializeField]
    private Slider _difficulty;
    [SerializeField]
    private Slider _asteroidSteps; // 
    [SerializeField]
    private Slider _powerupDensity;

    #endregion setups 

    #region init 
    private void Start()
    {
        ProfileData profile = StateMachineAsteroids.PLAYER_PROFILE;

        _maxHealth.text = profile.hpMaxLives.ToString();
        _accelNumber.text = profile.acceleration.ToString();
        _rotation.text = profile.rotationSpeed.ToString();

        _asteroidSteps.value = profile.asteroidDestroySteps;
        _difficulty.value = profile.difficulty;
        _powerupDensity.value = profile.chanceToCreatePickup;
    }
    #endregion init 

    #region apply 
    public void Apply()
    {
        ProfileData profile = StateMachineAsteroids.PLAYER_PROFILE;
        profile.hpMaxLives = Int32.Parse(_maxHealth.text);
        profile.acceleration = float.Parse(_accelNumber.text);
        profile.rotationSpeed = float.Parse(_rotation.text);

        profile.asteroidDestroySteps = Mathf.RoundToInt(_asteroidSteps.value);
        profile.difficulty = Mathf.RoundToInt(_difficulty.value);
        profile.chanceToCreatePickup = Mathf.RoundToInt(_powerupDensity.value);

        // Int32.Parse(input)
        StateMachineAsteroids.Instance().SaveGame();

        GameManagerAsteroids.Instance().playerManager.UpdateDifficultyAndReset();
        GameManagerAsteroids.Instance().asteroidManager.UpdateDifficultyAndReset();
    }

    public void Reset()
    {
        _accelNumber.text = "200";
        _rotation.text = "80";
        _maxHealth.text = "10";
        _difficulty.value = 1;
        _asteroidSteps.value = 2;
        _powerupDensity.value = 4;

        ProfileData profile = StateMachineAsteroids.PLAYER_PROFILE;
        profile.hpMaxLives = 3;
        profile.acceleration = 200;
        profile.rotationSpeed = 80;
        profile.asteroidDestroySteps = 2;
        profile.difficulty = 1;

        StateMachineAsteroids.Instance().SaveGame();
    }

    public void Restart()
    {
        StateMachineAsteroids.Instance().SaveGame();
        if (StateMachineAsteroids.PLAYER_PROFILE.playIntro)
        {
            SceneManager.LoadScene(0);
        } else {
            SceneManager.LoadScene(1);
        }
    }
    #endregion apply 
}
