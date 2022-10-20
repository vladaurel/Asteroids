using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cinematic1
{
    public class CinematicPass : MonoBehaviour
    {
        #region variables 
        [SerializeField]
        private GameObject _playerShipVisual;
        [SerializeField]
        private GameObject _asteroid;
        #endregion variables 

        #region functionality 
        private void Awake()
        {
            // TODO ?!
            // generally if I do the loading and it says to skip into as an option, just load scene 2

        }

        private void Start()
        {
            _asteroid.SetActive(false);
            PhaseSwitch(1);
        }

        public void PhaseSwitch(int newPhase)
        {
            switch(newPhase)
            {
                case 1:
                    CinematicMoveShipToCenter phase1 = gameObject.AddComponent<CinematicMoveShipToCenter>();
                    phase1.Init(_playerShipVisual, this); break;

                // move asteroid in 
                case 2:
                    _asteroid.SetActive(true);
                    CinematicAsteroidKickIn phase2 = gameObject.AddComponent<CinematicAsteroidKickIn>();
                    phase2.Init(_asteroid, this); break;

                case 3:
                    CinematicCameraZoomout cineZoomout = gameObject.AddComponent<CinematicCameraZoomout>();
                    cineZoomout.Init(this);
                    break;
                    // camera zoom out

                case 4: gameObject.AddComponent<CinematicWaitForInput>();
                    break;

                default: Debug.LogError("Should never get here"); break;
            }
        }
        #endregion functionality 
    }
}
