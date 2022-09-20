using System;
using Controls;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;


namespace Managers
{
    public class InputManager  
    {
        public event Action OnKeyDownSpaceEvent;
        public event Action<Vector3> OnMouseClickEvent;
        
        private PauseManager _pauseManager;
        private JumpController _jumpController;
        private ClickController _clickController;
        
        [Inject]
        public InputManager( PauseManager pauseManagerArg, JumpController jumpControllerArg, ClickController clickControllerArg )
        {
            _pauseManager = pauseManagerArg;
            _jumpController = jumpControllerArg;
            _clickController = clickControllerArg;

            _jumpController.OnJumpEvent += Jump;
            _clickController.OnClickNotUIRestreactAreaReturnWorldCoordinateEvent += ClickNotUIRestreactAreaReturnWorldCoordinate;
        }
        
        
        private void Jump()
        {
            if(_pauseManager.GetPauseState())
                return;
                
            OnKeyDownSpaceEvent?.Invoke();
        }


        private void ClickNotUIRestreactAreaReturnWorldCoordinate(Vector3 clickPosition)
        {
            if(_pauseManager.GetPauseState())
                return;
            
            OnMouseClickEvent?.Invoke(clickPosition);
        }
    }
}