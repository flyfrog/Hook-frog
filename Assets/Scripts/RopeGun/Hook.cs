using System;
using UnityEngine;

namespace RopeGun
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class Hook : MonoBehaviour
    {
        public event Action<Collision> OnCollisionEnterHookEvent;
        public Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            Hide();
        }


        private void OnCollisionEnter(Collision other)
        {
            OnCollisionEnterHookEvent?.Invoke(other);
        }


        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);

        }

        public void SetPosition(Vector3 newPositionArg)
        {
            transform.position = newPositionArg;
        }

        public void SetRotation(Quaternion newRotationArg)
        {
            transform.rotation = newRotationArg;
        }


        public void SetVelocity(Vector3 velocityVectorArg)
        {
            _rigidbody.velocity = velocityVectorArg;
        }


        public Rigidbody GetRigidbody()
        {
            return _rigidbody;
        }


    }
}