using System;
using Player;
using UI;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class ProgressManager: ITickable 
    {
        private UIProgressView _uiProgressView;
        private PlayerView _playerView;
        private FinishArea.FinishAreaController _finishAreaController;
        private const float _timeDrawProgress = 1f;
        private float _currentTimeDrawProgress;


        [Inject]
        public ProgressManager(UIProgressView uiProgressViewArg, PlayerView playerViewArg, FinishArea.FinishAreaController finishAreaControllerArg)
        {
            _uiProgressView = uiProgressViewArg;
            _playerView = playerViewArg;
            _finishAreaController = finishAreaControllerArg;
        }
        

        public void Tick()
        {
            if (CheckTimeDrawProgress())
            {
                DrawDistanceProgress(CheckDistance());
            }
            
        }

        private bool CheckTimeDrawProgress()
        {
            if (_currentTimeDrawProgress < _timeDrawProgress)
            {
                _currentTimeDrawProgress += Time.deltaTime;
                return false;
            }

            _currentTimeDrawProgress = 0;
            return true;
        }

        private int CheckDistance()
        {
            float _startXPosition = _playerView.GetStartPosition().x;
            float _finishXPosition = _finishAreaController.GetPosition().x;
            float _fullDistance = _finishXPosition - _startXPosition;
            float playerXPosition = _playerView.GetPosition().x;
          
            int progressInPercent =  (int) Math.Ceiling( (100 / (_fullDistance / playerXPosition)) );

            progressInPercent = Math.Clamp(progressInPercent, 0, 100);
            return progressInPercent;
        }

        private void DrawDistanceProgress(int progress)
        {
            _uiProgressView.SetProgress(progress);
        }
    }
}