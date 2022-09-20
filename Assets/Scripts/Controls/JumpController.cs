using System;
using UI;
using UnityEngine;
using Zenject;

namespace Controls
{
    public class JumpController: ITickable
    {
    
        private UIControlJumpView _uiControlJumpView;
        public event Action OnJumpEvent;
        private ClickController _clickController;
        private CheckRaycastClickOnUIElement _checkRaycastClickOnUI = new CheckRaycastClickOnUIElement();
        private RectTransform _jumpButtonRectTransform;

        [Inject]
        public JumpController(UIControlJumpView uiControlJumpViewArg, ClickController clickControllerArg)
        {
            _uiControlJumpView = uiControlJumpViewArg;
            _jumpButtonRectTransform = _uiControlJumpView.GetJumpButtonRectTransform(); 
            
            _clickController = clickControllerArg;
            _clickController.OnClickReturnScreenCoordinateEvent += CheckClickOnUIJumpButton;
        }

        public void Tick()
        {
            CheckKeyboardJump();
        }

        private void CheckClickOnUIJumpButton(Vector3 pointPositionArg)
        {
            if (_checkRaycastClickOnUI.CheckContains(pointPositionArg, _jumpButtonRectTransform))
            {
                Jump();
            }
        }
        
        private void CheckKeyboardJump()
        {
            if (Input.GetKeyDown(KeyCode.Space)) // для отладки 
            {
                Jump();
            }
        }

        private void Jump()
        {
            OnJumpEvent?.Invoke();
        }
    
    
    
    }
}