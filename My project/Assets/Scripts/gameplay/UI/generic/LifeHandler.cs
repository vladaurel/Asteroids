using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeHandler : MonoBehaviour
{
    #region variables 
    [SerializeField]
    private GameObject _lifeDisplay;

    private List<GameObject> _livesArray = new List<GameObject>();
    private float _spacing = -15f;
    #endregion variables 


    #region init 
    private void Awake()
    {
        // float  orthographicWidth = Camera.main.orthographicSize * Camera.main.aspect;
        // float orthographicHeight = orthographicWidth / Camera.main.aspect;
        _lifeDisplay.transform.position = new Vector2(Camera.main.pixelWidth - 20, Camera.main.pixelHeight-20);
    }

    private void Start() 
    { 
        SetupLives(StateMachineAsteroids.PLAYER_PROFILE.hpMaxLives); 
        StateMachineAsteroids.PLAYER_PROFILE.currentLives = StateMachineAsteroids.PLAYER_PROFILE.hpMaxLives; 
    } 
    #endregion init 


    #region setup lives  
    public int DecreaseLife()
    {
        if (_livesArray.Count > 1)
        {
            Destroy(_livesArray[_livesArray.Count - 1]);
            _livesArray.RemoveAt(_livesArray.Count - 1);
            return StateMachineAsteroids.PLAYER_PROFILE.currentLives--;
        } else {
            return 0;
        }
    }

    public void IncreaseLives() 
    {
        ProfileData profile = StateMachineAsteroids.PLAYER_PROFILE;
        profile.currentLives++;
        if(profile.currentLives > profile.hpMaxLives)
        {
            profile.currentLives = profile.hpMaxLives;
        }
        SetupLives(profile.currentLives); 
    } 

    public void SetupLives(int newAmount) 
    {
        for(int i=_livesArray.Count-1 ; i>0 ; i--) 
        { 
            Destroy(_livesArray[i]); 
        } 
        _livesArray.Clear(); 
        _livesArray.Add(_lifeDisplay); 

        StateMachineAsteroids.PLAYER_PROFILE.currentLives = newAmount; 
        for (int i=1;i<newAmount;i++) 
        { 
            GameObject duplicateLife = Instantiate(_lifeDisplay,_lifeDisplay.transform.parent); 
            duplicateLife.transform.position = _lifeDisplay.transform.position + new Vector3(i * _spacing, 0 , 0);
            duplicateLife.name = "DUPLICATE LIFE " + i.ToString();
            _livesArray.Add(duplicateLife); 
        } 
    } 
    #endregion setup lives 
}
