/**
 * I would normally never place this on the player - but doing so due to time constraints. 
 * I'd add this externally with a state machine ( and not make it a MonoBehaviour ) - so it could be reused on other players/objects, and not mandatory connected 
 */ 
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
        if(newTime<=Time.time) return; // should never happen

        if(newTime>_newInvulnTime) _newInvulnTime = newTime;

        enabled = true;
        _player.SetNewInvulnTime(newTime);
        _sprite.color = new Color(1, 0, 0, 1);
    }
    

    // would usually do this with async or IEnumerator ( or even IAsyncEnumerator :)) ) - however placing as is due to time constraints.
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
