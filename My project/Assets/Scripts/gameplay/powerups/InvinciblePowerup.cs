/**
 * 
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvinciblePowerup : MonoBehaviour
{
    #region variables 
    private float _newInvulnTime;
    private PlayerClass _player;

    private SpriteRenderer _sprite;
    #endregion variables 


    #region init 
    private void Start()
    {
        _player = gameObject.GetComponent<PlayerClass>();
        _sprite = gameObject.GetComponent<SpriteRenderer>();
        this.enabled = false;
    }
    #endregion init 

    #region functionality 
    public void SetupNewInvulnerabilityTime(float newTime)
    {
        if(newTime<=Time.time)
        {
            return; // should never happen
        }

        if(newTime>_newInvulnTime)
        {
            _newInvulnTime = newTime;
        }
        enabled = true;
        _player.SetNewInvulnTime(newTime);
        _sprite.color = new Color(1, 0, 0, 1);
    }
    
    private void Update()
    {
        if(Time.time>_newInvulnTime)
        {
            this.enabled = false;
            _sprite.color = new Color(1, 1, 1, 1); 
        }
    }
    #endregion functionality 
}
