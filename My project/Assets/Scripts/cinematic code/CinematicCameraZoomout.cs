using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cinematic1
{
    public class CinematicCameraZoomout : MonoBehaviour
    {
        #region variables 
        private bool _allowCheck = true;

        private float _maxZoomout = 5f;
        private float _speed = 2f;

        private Camera _cam;
        private CinematicPass _cinematicPass;
        #endregion variables 

        #region init 
        private void Awake()
        {
            _cam = Camera.main;
        }

        public void Init(CinematicPass _pass)
        {
            _cinematicPass = _pass;
        }
        #endregion init 

        #region update
        private void Update()
        {
            // Debug.LogError(_cam.orthographicSize);
            if (_allowCheck)
            {
                _cam.orthographicSize += _speed * Time.deltaTime;
                if (_cam.orthographicSize > _maxZoomout)
                {
                    _cam.orthographicSize = _maxZoomout;
                    _allowCheck = false;
                    this.enabled = false;
                    _cinematicPass.PhaseSwitch(4);
                }
            }
        }
        #endregion update 
    }
}
