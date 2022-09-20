using Managers;
using Player;
using ScriptableObjectScript;
using Sound;
using UnityEngine;
using Zenject;

namespace RopeGun
{
    public class RopeGun : MonoBehaviour
    {
        private float _speedHook;
        private float ROPE_SPRING;
        private float ROPE_DAMPER;
        private float MAX_ROPE_LENGTH;
        
        private float _startRopeLength = 1f;
        private float _ropeDistance;
        private bool _inRope;
        
        private RopeRenderer _ropeRender;
        private Hook _hook;
        private RopeState _currentRopeState;
        private SpringJoint _ropeSpring;
        private PlayerMoveController _playerMoveController;
        private InputManager _inputManager;
        private GameObject _playerBody;
        private FixedJoint _fixedJoinhook;
        private RopeGunSound _ropeGunSound;
        private RotateRopeGunController _rotateRopeGunController;
        private PlayerSettingsSO _playerSettingsSO;

        [Inject]
        private void Construct(InputManager inputManagerArg, Hook hookArg, RopeRenderer ropeRendererArg, 
            RopeGunSound ropeGunSoundArg, RotateRopeGunController rotateRopeGunControllerArg, 
            PlayerView playerViewArg, PlayerSettingsSO playerSettingsSOArg)
        {
            _inputManager = inputManagerArg;
            _hook = hookArg;
            _ropeRender = ropeRendererArg;
            _ropeGunSound = ropeGunSoundArg;
            _rotateRopeGunController = rotateRopeGunControllerArg;
            _playerBody = playerViewArg.gameObject;
            _playerSettingsSO = playerSettingsSOArg;
            SetRopeGunSettings();
        }

        private void SetRopeGunSettings()
        {
         _speedHook = _playerSettingsSO.speedHook;
         ROPE_SPRING = _playerSettingsSO.ROPE_SPRING;
         ROPE_DAMPER = _playerSettingsSO.ROPE_DAMPER;
         MAX_ROPE_LENGTH = _playerSettingsSO.MAX_ROPE_LENGTH;
        }
        

        private void OnEnable()
        {
            _inputManager.OnMouseClickEvent += ShotHook;
            _hook.OnCollisionEnterHookEvent += EnterHookOnCollisionEnterEnter;
        }

        private void OnDisable()
        {
            _inputManager.OnMouseClickEvent -= ShotHook;
            _hook.OnCollisionEnterHookEvent -= EnterHookOnCollisionEnterEnter;
        }

        void Update()
        {
            CheckExcessMaxLengthRope();
            CheckRopeStatusAndThenDrawIt();
        }

        private void CheckExcessMaxLengthRope()
        {
            if (_currentRopeState == RopeState.Fly)
            {
                float ropeLength = GetRopeDistance();
                if (ropeLength > MAX_ROPE_LENGTH)
                {
                    DeliteRope();
                }
            }
        }

        private void CheckRopeStatusAndThenDrawIt()
        {
            if (_currentRopeState == RopeState.Fly || _currentRopeState == RopeState.Connected)
            {
                _ropeRender.DrawRope(transform.position, _hook.transform.position, _ropeDistance);
            }
            else
            {
                _ropeRender.HideRope();
            }
        }


        public void ShotHook(Vector3 clickPosition)
        {
            _rotateRopeGunController.RotateGun(clickPosition);
            _ropeGunSound.PlayRopeGunShot();
            DeliteRope();
            PrepareHookForShot();
            _currentRopeState = RopeState.Fly;
        }

        private void PrepareHookForShot()
        {
            _hook.Show();
            _hook.SetPosition(transform.position);
            _hook.SetRotation(transform.rotation);
            _hook.SetVelocity(transform.forward * _speedHook);
        }


        private float GetRopeDistance()
        {
            return Vector3.Distance(transform.position, _hook.transform.position);
        }

        public bool GetInRopeState()
        {
            return _inRope;
        }

        private void EnterHookOnCollisionEnterEnter(Collision other)
        {
            if (other.rigidbody)
            {
                _ropeGunSound.PlayHookStuck();
                CreateJoinForRope(other);
                CreateSpringForRope();
            }
            else
            {
                _ropeGunSound.PlayHookNotStuck();
                DeliteRope();
            }
        }

        private void CreateJoinForRope(Collision other)
        {
            if(_fixedJoinhook!=null)
                return;
            
            _fixedJoinhook = _hook.gameObject.AddComponent<FixedJoint>();
            _fixedJoinhook.connectedBody = other.rigidbody;
        }

        public void CreateSpringForRope()
        {
            _ropeSpring = _playerBody.AddComponent<SpringJoint>();
            _ropeSpring.connectedBody = _hook.GetRigidbody();
            _ropeSpring.autoConfigureConnectedAnchor = false;
            _ropeSpring.connectedAnchor = Vector3.zero;
            _ropeSpring.spring = ROPE_SPRING;
            _ropeSpring.damper = ROPE_DAMPER;
            _ropeDistance = GetRopeDistance();
            _ropeSpring.maxDistance = _ropeDistance;
            _currentRopeState = RopeState.Connected;
            _inRope = true;
        }

        public void DeliteRope()
        {
            DestroyRopeSpring();
            DestroyJoinForRope();
            
            _hook.Hide();
            _ropeDistance = _startRopeLength;
            _currentRopeState = RopeState.Disabled;
            _inRope = false;
        }

        private void DestroyJoinForRope()
        {
            Destroy(_fixedJoinhook);
        }

        private void DestroyRopeSpring()
        {
            Destroy(_ropeSpring);
        }
    }
}