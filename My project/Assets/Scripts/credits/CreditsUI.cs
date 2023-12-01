using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Profile.SaveAndLoad;

namespace Credits
{
    public class CreditsUI : MonoBehaviour
    {
        #region variables 
        [SerializeField] private Toggle _replayIntro;
        [SerializeField] private Text _scoreText;
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
                SceneManager.LoadSceneAsync(1);
            } else {
                SceneManager.LoadSceneAsync(2);
            }
        }
        #endregion button press 
    }
}
