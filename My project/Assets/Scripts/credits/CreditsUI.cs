using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Credits
{
    public class CreditsUI : MonoBehaviour
    {
        #region variables 
        [SerializeField]
        private Toggle _replayIntro;
        [SerializeField]
        private Text _scoreText;
        #endregion variables 

        #region init
        private void Awake()
        {
            LoadData load = new LoadData();
            ProfileData profile = load.LoadProfile("default");

            _replayIntro.isOn = profile.playIntro;
            _scoreText.text = profile.score.ToString();
        }
        #endregion init 

        #region button press 
        public void OnRestart()
        {
            if(_replayIntro.isOn)
            {
                SceneManager.LoadScene(1);
            } else {
                SceneManager.LoadScene(2);
            }
        }
        #endregion button press 
    }
}
