using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cinematic1
{
    public class CinematicAsteroidKickIn : CinematicMoveShipToCenter
    {
        #region 
        protected override void SetupInitialPosition()
        {

            float orthographicWidth = Camera.main.orthographicSize * Camera.main.aspect;
            // float orthographicHeight = orthographicWidth / Camera.main.aspect;

            _initialPosition = _objectVisual.transform.position = new Vector3(orthographicWidth, 0f, 0f);// orthographicHeight / 2, 0f);
        }

        override protected void SetupFinalPosition()
        {
            float orthographicWidth = Camera.main.orthographicSize * Camera.main.aspect;
            // _finalPosition = _objectVisual.transform.position + new Vector3((orthographicWidth*0.4), 0, 0);
            _finalPosition = new Vector3((orthographicWidth * 4 / 5), 0, 0);
            _deltaDistance = orthographicWidth / 5;
            _speed = 1f;
        }

        protected override void FinalizePhase()
        {
            _cinematicPass.PhaseSwitch(3);
        }
        #endregion
    }
}
