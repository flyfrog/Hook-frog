using System;
using Managers;
using ScriptableObjectScript;
using Sound;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerMoveController : IDisposable, IInitializable
    {
        private float _jumpForce = 13f;
        private float _maxAngleGroundForJump = 45f;
        
        private int isFrameCounterCollissionBugForManyNormalVec3 = 0;
        private bool _isGrounded = false;
      //  private float _defaultHeight = 1f;
      //  private float _crouchHeight = 0.5f;
      //  private float _speedCrouch = 15f;
      //  private float _newHeight = 1f;
        private InputManager _inputManager;
        private RopeGun.RopeGun _ropeGun;
        private PlayerView _playerView;
        private PlayerSound _playerSound;
        private PlayerSettingsSO _playerSettingsSO;

        [Inject]
        private PlayerMoveController(InputManager inputManagerArg, RopeGun.RopeGun ropeGunArg, PlayerView playerViewArg, PlayerSound playerSoundArg, PlayerSettingsSO playerSettingsSOArg)
        {
            _inputManager = inputManagerArg;
            _ropeGun = ropeGunArg;
            _playerView = playerViewArg;
            _playerSound = playerSoundArg;
            _playerSettingsSO = playerSettingsSOArg;
            SetPlayerSettings();
        }

        private void SetPlayerSettings()
        {
          _jumpForce = _playerSettingsSO.jumpForce;
          _maxAngleGroundForJump = _playerSettingsSO.maxAngleGroundForJump;
        }


        public void Initialize()
        {
            _inputManager.OnKeyDownSpaceEvent += TryJump;
            _playerView.OnCollisionStayEvent += OnCollisionStay;
            _playerView.OnCollisionExitEvent += OnCollisionExit;
        }

        public void Dispose()
        {
            _inputManager.OnKeyDownSpaceEvent -= TryJump;
            _playerView.OnCollisionStayEvent -= OnCollisionStay;
            _playerView.OnCollisionExitEvent -= OnCollisionExit;
        }

        private void TryJump()
        {
           
            if (_isGrounded || _ropeGun.GetInRopeState())
                Jump();
            
            if (_ropeGun.GetInRopeState())
                _ropeGun.DeliteRope();
        }


        private void OnCollisionStay(Collision other)
        {
            DetectGround(other);
        }


        private void OnCollisionExit()
        {
            _isGrounded = false;
        }

 
        private void DetectGround(Collision other)
        {
            for (int i = 0; i < other.contactCount; i++)
            {
                float angle = Vector3.Angle(other.contacts[i].normal, Vector3.up);
                if (angle < _maxAngleGroundForJump)
                {
                    _isGrounded = true;
                    isFrameCounterCollissionBugForManyNormalVec3 = 4;
                    return;
                }
            }

            if (isFrameCounterCollissionBugForManyNormalVec3 <= 0)
            {
                _isGrounded = false;
            }
        }


        public void Jump()
        {
            _playerSound.PlayJump();
            _playerView.Jump(_jumpForce);
        }
    }
}