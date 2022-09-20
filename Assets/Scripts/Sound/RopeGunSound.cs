using UnityEngine;

namespace Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class RopeGunSound : MonoBehaviour
    {
    
        [SerializeField] private AudioClip _shotRopeGun;
        [SerializeField] private AudioClip _hookStuck;
        [SerializeField] private AudioClip _hookNotStuck;
        private AudioSource _audioSource;
        private VariablePithSound _variablePithSound;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _variablePithSound = new VariablePithSound(_audioSource, 0.8f, 1.3f);
        }
    
        public void PlayRopeGunShot()
        {
            _variablePithSound.Play(_shotRopeGun);
        }
    
        public void PlayHookStuck()
        {
            _variablePithSound.Play(_hookStuck);
        }
    
        public void PlayHookNotStuck()
        {
            _variablePithSound.Play(_hookNotStuck);
        }
    
        
    }
}