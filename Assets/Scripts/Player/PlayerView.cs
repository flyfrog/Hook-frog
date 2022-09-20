using System;
using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        public event Action<Collision> OnCollisionStayEvent;
        public event Action OnCollisionExitEvent;
        public event Action<Collision> OnCollisionEnterEvent;
        private Vector3 _startPosition;
        
        private void Start()
        {
            _startPosition = transform.position;
            _rigidbody = GetComponent<Rigidbody>();
        }


        public void Jump(float jumpForceArg)
        {
            Vector3 jumpVector = Vector3.up * jumpForceArg;
            _rigidbody.AddForce(jumpVector, ForceMode.VelocityChange);
        }


        private void OnCollisionEnter(Collision collision)
        {
            OnCollisionEnterEvent?.Invoke(collision);
        }

        private void OnCollisionStay(Collision other)
        {
            OnCollisionStayEvent?.Invoke(other);
        }


        private void OnCollisionExit(Collision other)
        {
            OnCollisionExitEvent?.Invoke();
        }
        
        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public Vector3 GetStartPosition()
        {
            return _startPosition;
        }
 
    }
}

