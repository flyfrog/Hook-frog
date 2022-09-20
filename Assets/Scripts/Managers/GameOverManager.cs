using Sound;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class GameOverManager
    {
        private UIGameOverView _uiGameOverView;
        private PauseManager _pauseManager;
        private RestartManager _restartManager;
        private UISound _uiSound; 
        
        [Inject]
        public GameOverManager(UIGameOverView uiGameOverViewArg, PauseManager pauseManagerArg, RestartManager restartManagerArg, UISound uiSoundArg)
        {
             
            _uiGameOverView = uiGameOverViewArg;
            _uiGameOverView.onClickRestartGameButtonEvent += OnClickRestartGame;
            _pauseManager = pauseManagerArg;
            _restartManager = restartManagerArg;
            _uiSound = uiSoundArg;
        }

        private void OnClickRestartGame()
        {
            _uiSound.PlayClick();
            _uiGameOverView.HidePanel();
            _pauseManager.PauseOff();
            _restartManager.RestartGame();
        }
        

        public void GameOver()
        {
            _uiSound.PlayOpenPanel();
            _uiGameOverView.ShowPanel();
            _pauseManager.PauseOn();
        }
        
        
    }
}