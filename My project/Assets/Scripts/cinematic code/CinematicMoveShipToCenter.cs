using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cinematic1
{
    public class CinematicMoveShipToCenter : MonoBehaviour
    {
        #region variables 
        private float _startTime;
        protected GameObject _objectVisual;
        protected float _speed = 0.4f;

        protected Vector3 _initialPosition;
        protected Vector3 _finalPosition;
        protected float _deltaDistance;

        protected CinematicPass _cinematicPass;
        #endregion variables 


        #region init 
        public void Init(GameObject objectVisual, CinematicPass cinematicPass)
        {
            _startTime = Time.time;

            _objectVisual = objectVisual;
            _cinematicPass = cinematicPass;

            // the initial setup
            Camera.main.orthographicSize = 1f;

            SetupInitialPosition();
            SetupFinalPosition();
        }

        protected virtual void SetupInitialPosition()
        {
            float orthographicWidth = Camera.main.orthographicSize * Camera.main.aspect;
            // float orthographicHeight = orthographicWidth / Camera.main.aspect;

            _initialPosition = _objectVisual.transform.position = new Vector3(-orthographicWidth, 0f, 0f);// orthographicHeight / 2, 0f);
        }

        protected virtual void SetupFinalPosition()
        {
            float orthographicWidth = Camera.main.orthographicSize * Camera.main.aspect;
            // _finalPosition = _objectVisual.transform.position + new Vector3(orthographicWidth, 0, 0); // (orthographicWidth / 2)
            _finalPosition = new Vector3(0, 0, 0);
            _deltaDistance = orthographicWidth / 2;
        }
        #endregion init 


        #region functionality 
        public void Update()
        {
            float distCovered = (Time.time - _startTime) * _speed;

            float fractionOfJourney = distCovered / _deltaDistance;
            // Debug.LogError(fractionOfJourney + "| Fraction of journey.");

            _objectVisual.transform.position = Vector3.Lerp(_initialPosition, _finalPosition, fractionOfJourney);

            if(fractionOfJourney>=1)
            {
                this.enabled = false;
                FinalizePhase();
                Destroy(this);
            }
        }

        protected virtual void FinalizePhase()
        {
            _cinematicPass.PhaseSwitch(2);
        }
        #endregion functionality 
    }
}
