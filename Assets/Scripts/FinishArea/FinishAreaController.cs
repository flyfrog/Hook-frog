using System;
using Player;
using UnityEngine;

namespace FinishArea
{
    [RequireComponent(typeof(Collider))]
    public class FinishAreaController : MonoBehaviour
    {
        public event Action OnPlayerEnterInFinishAreaEvent;
        private void OnTriggerEnter(Collider other)
        { 
            if(other.attachedRigidbody.GetComponent<PlayerView>())
            {
                OnPlayerEnterInFinishAreaEvent?.Invoke();
            }
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }
    
    }
}
