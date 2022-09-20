using Managers;
using UnityEngine;
using Zenject;

namespace Player
{
    public class RotateRopeGunController : MonoBehaviour
    {
        
        public void RotateGun(Vector3 clickPosition)
        {
            Vector3 aimPositionVector = clickPosition;
            aimPositionVector.z = 0f;
            transform.LookAt(aimPositionVector);
        }
    }
}