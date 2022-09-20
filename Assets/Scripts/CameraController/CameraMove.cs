using UnityEngine;

namespace CameraController
{
    public class CameraMove : MonoBehaviour
    {
        [SerializeField] private GameObject _target; 
        [SerializeField] private float _cameraSpeed; 
    

        private void LateUpdate() {
            Vector3 newPositionVector = Vector3.Lerp(transform.position,_target.transform.position, Time.deltaTime* _cameraSpeed);
            transform.position = newPositionVector; 
        }  
    
    }
}
