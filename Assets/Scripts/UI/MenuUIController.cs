using Managers;
using Sound;
using UnityEngine;
using Zenject;

namespace UI
{
    public class MenuUIController
    {
        
        private UIMenuView _uiMenuView;
        private PauseManager _pauseManager;
        private RestartManager _restartManager;
        private UISound _uiSound;
       

        [Inject]
        public MenuUIController(UIMenuView uiMenuViewArg, PauseManager pauseManagerArg, RestartManager restartManagerArg, UISound uiSoundArg )
        {
            _uiMenuView = uiMenuViewArg;
            _uiMenuView.onClickButtonOpenMenuEvent += OpenMenuPanel;
            _uiMenuView.onClickButtonRestartGameEvent += Restart;
            _uiMenuView.onClickButtonBackInGameEvent += BackInGame;
            _pauseManager = pauseManagerArg;
            _restartManager = restartManagerArg;
            _uiSound = uiSoundArg;
        }

        private void BackInGame()
        {
            ClickSound();
            _pauseManager.PauseOff();
            _uiMenuView.HidePanel();
        }

        private void Restart()
        {
            ClickSound();
            _pauseManager.PauseOff();
            _restartManager.RestartGame();
        }

        public void OpenMenuPanel()
        {  
            ClickSound();
            _uiSound.PlayOpenPanel();
            _pauseManager.PauseOn();
            _uiMenuView.ShowPanel();
        }

        
        private void ClickSound()
        {
            _uiSound.PlayClick();
        }
        
   
    }
}