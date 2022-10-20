using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAsteroid : MonoBehaviour
{
    #region lives 
    private int _steps;


    private float orthographicWidth;
    private float orthographicHeight;

    private float _timeToRecalc = 3f;

    private Rigidbody2D _body;
    #endregion lives 


    #region init 
    private void Awake()
    {
        _body = gameObject.GetComponent<Rigidbody2D>();

        orthographicWidth = Camera.main.orthographicSize * Camera.main.aspect;
        orthographicHeight = orthographicWidth / Camera.main.aspect;
    }

    public void ReadyForReuse()
    {
        _body.velocity = Vector2.zero;
        _body.angularVelocity = 0;
        gameObject.SetActive(true);
    }

    public void Init(int quadrant, int steps, float scale, float difficulty)
    {
        _timeToRecalc += Time.time;

        transform.localScale = new Vector3(scale, scale);
        _steps = steps;

        transform.localScale = new Vector3(scale, scale, scale);

        switch (quadrant)
        {
            case 1: transform.position = new Vector2(orthographicWidth + 0.5f, Random.Range(-orthographicHeight / 2, orthographicHeight / 2)); break; // right  
            case 2: transform.position = new Vector2(Random.Range(-orthographicWidth / 2, orthographicWidth / 2), orthographicHeight + 0.5f); break; // up 
            case 3: transform.position = new Vector2(-orthographicWidth - 0.5f, Random.Range(-orthographicHeight / 2, orthographicHeight / 2)); break; // left 
            case 4: transform.position = new Vector2(Random.Range(-orthographicWidth / 2, orthographicWidth / 2), -orthographicHeight - 0.5f); break; // down 
        }

        Transform player = GameManagerAsteroids.Instance().playerManager.player.transform;

        float rot_z = Mathf.Atan2(transform.position.y - player.position.y, transform.position.x - player.position.x) * Mathf.Rad2Deg;// + (Random.RandomRange(-15f, 15f));
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

        // float pushForce = (Time.time/10 );
        // pushForce = Mathf.Clamp(pushForce, 0, 20+ difficulty*5);
        // gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * pushForce);

        float extraDifficulty = Time.time * difficulty/9;
        Mathf.Clamp(extraDifficulty, 0, difficulty/3);

        float angleSetup = (rot_z + Random.Range(-45,45)) * Mathf.Deg2Rad;
        gameObject.GetComponent<Rigidbody2D>().velocity = -new Vector2(Mathf.Cos(angleSetup) * (1.2f + extraDifficulty), Mathf.Sin(angleSetup) * (1.2f + extraDifficulty));
    }


    // InitSmallAsteroid(angle,stepsToDestroy,scale,currentDifficulty); 
    public void InitSmallAsteroid( Vector2 newPosition , float angle, int stepsToDestroy, float scale, float currentDifficulty)
    {
        _timeToRecalc += Time.time;
        _steps = stepsToDestroy;

        transform.localScale = new Vector3(scale, scale, scale);

        // orthographicWidth = Camera.main.orthographicSize * Camera.main.aspect;
        // orthographicHeight = orthographicWidth / Camera.main.aspect;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.position = newPosition;

        float angleSetup = angle* Mathf.Deg2Rad;
        gameObject.GetComponent<Rigidbody2D>().velocity = -new Vector2(Mathf.Cos(angleSetup) * (1.2f + currentDifficulty), Mathf.Sin(angleSetup) * (1.2f + currentDifficulty));
        // gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * (30 + currentDifficulty));
    }
    #endregion init 


    #region collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!StateMachineAsteroids.PLAYER_PROFILE.footbalMode)
        {
            if (collision.collider.gameObject.layer != gameObject.layer)
            {
                _steps--;
                if (_steps > 0)
                {
                    float angle1 = transform.rotation.eulerAngles.z - 90;
                    float angle2 = transform.rotation.eulerAngles.z + 90;
                    Vector3 difference = new Vector3(transform.localScale.x * Mathf.Cos(angle1 * Mathf.Deg2Rad), transform.localScale.y * Mathf.Sin(angle1 * Mathf.Deg2Rad), 0);
                    GameManagerAsteroids.Instance().asteroidManager.CreateNewAsteroidAtLocation(transform.position + difference, angle2, _steps, transform.localScale.x * .75f);
                    GameManagerAsteroids.Instance().asteroidManager.CreateNewAsteroidAtLocation(transform.position - difference, angle1, _steps, transform.localScale.x * .75f);
                } else {
                    StateMachineAsteroids.PLAYER_PROFILE.score++;
                    StateMachineAsteroids.Instance().uiManager.UpdateScore();

                    // GameManagerAsteroids.Instance().pickupManager.ChanceToAddPowerup(transform.position);
                }
                GameManagerAsteroids.Instance().pickupManager.ChanceToAddPowerup(transform.position);

                GameManagerAsteroids.Instance().asteroidManager.CleanupAsteroid(this);
                // Destroy(gameObject); 
            }
        } else {
            if(collision.collider.gameObject.layer == gameObject.layer)
            {
                StateMachineAsteroids.PLAYER_PROFILE.score++;
                StateMachineAsteroids.Instance().uiManager.UpdateScore();
            }
        }
    }
    #endregion collision 




    #region update
    private void Update()
    {
        if (Time.time > _timeToRecalc)
        {
            if (transform.position.x < (-orthographicWidth  - 0.51f))
            {
                if (!StateMachineAsteroids.PLAYER_PROFILE.footbalMode)
                {
                    transform.position = new Vector2(orthographicWidth + 0.45f, transform.position.y);
                } else {
                    FinalizeAsteroidDestruction(true);
                }
            } else {
                if (transform.position.x > (orthographicWidth + 0.51f))
                {
                    if (!StateMachineAsteroids.PLAYER_PROFILE.footbalMode)
                    {
                        transform.position = new Vector2(-orthographicWidth - 0.45f, transform.position.y);
                    } else {
                        FinalizeAsteroidDestruction(true);
                    }
                }
            }

            if (transform.position.y < (-orthographicHeight - 0.51f))
            {
                if (!StateMachineAsteroids.PLAYER_PROFILE.footbalMode)
                {
                    transform.position = new Vector2(transform.position.x, orthographicHeight + 0.45f);
                } else {
                    FinalizeAsteroidDestruction(true);
                }
            } else {
                if (transform.position.y > (orthographicHeight + 0.51f))
                {
                    if (!StateMachineAsteroids.PLAYER_PROFILE.footbalMode)
                    {
                        transform.position = new Vector2(transform.position.x, -orthographicHeight - 0.45f);
                    } else {
                        FinalizeAsteroidDestruction(true);
                    }
                }
            }
        }
    }

    public void FinalizeAsteroidDestruction(bool footbalMode = false)
    {
        // add to score 
        if (footbalMode)
        {
            
        } else {
            StateMachineAsteroids.PLAYER_PROFILE.score++;
            StateMachineAsteroids.Instance().uiManager.UpdateScore();
            GameManagerAsteroids.Instance().pickupManager.ChanceToAddPowerup(transform.position);
        }

        // remove from list 
        GameManagerAsteroids.Instance().asteroidManager.CleanupAsteroid(this);
        // Destroy(gameObject);
    }
    #endregion update 
}
