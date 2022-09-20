using FinishArea;
using Sound;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class WinManager
    {
        private UIWinView _uiWinView;
        private RestartManager _restartManager;
        private UISound _uiSound;
        private PauseManager _pauseManager;
        private FinishAreaController _finishAreaController;
        
        [Inject]
        public WinManager(UIWinView uiWinViewArg, RestartManager restartManagerArg,UISound uiSoundArg,PauseManager pauseManagerArg, FinishAreaController finishAreaControllerArg)
        {
            _uiWinView = uiWinViewArg;
            _restartManager = restartManagerArg;
            _uiSound = uiSoundArg;
            _pauseManager = pauseManagerArg;
            _finishAreaController = finishAreaControllerArg;

            _uiWinView.onClickRestartGameButtonEvent += OnClickRestartGame;
            _finishAreaController.OnPlayerEnterInFinishAreaEvent += PlayerInFinishArea;
        }

        private void PlayerInFinishArea()
        {
            Win();
        }

        private void Win()
        {
            Debug.Log(111);
            _uiSound.PlayOpenPanel();
            _uiWinView.ShowPanel();
            _pauseManager.PauseOn();
        }

        private void OnClickRestartGame()
        {
            _uiSound.PlayClick();
            _uiWinView.HidePanel();
            _pauseManager.PauseOff();
            _restartManager.RestartGame();
        }


    }
}