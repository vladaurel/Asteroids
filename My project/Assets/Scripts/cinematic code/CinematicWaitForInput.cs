using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cinematic1
{
    public class CinematicWaitForInput : MonoBehaviour
    {

        #region variables 
        private bool _allowCheck = true;
        #endregion variables 


        #region update 
        private void Update()
        {
            if(_allowCheck)
            {
                if(Input.anyKeyDown)
                {
                    
                    _allowCheck = false;
                    this.enabled = false;

                    SceneManager.LoadScene(1); // this will unload everything 
                }
            }
        }
        #endregion update
    }
}
