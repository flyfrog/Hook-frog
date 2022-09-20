using Damage;
using UnityEngine;

namespace Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class EnvironmenttSound : MonoBehaviour
    {
    
        [SerializeField] private AudioClip _wallHit;
        [SerializeField] private AudioClip _lavalTouch;
        [SerializeField] private AudioClip _spikeTouch;
        private AudioSource _audioSource;
        private VariablePithSound _variablePithSound;
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _variablePithSound = new VariablePithSound(_audioSource, 0.8f, 1.3f);
        }
    
        public void PlayWallHit()
        {
            _variablePithSound.Play(_wallHit);
        }
    
        public void PlayLavaTouch()
        {
            _audioSource.PlayOneShot(_lavalTouch);
        }
    
        public void PlaySpikeTouch()
        {
            _audioSource.PlayOneShot(_spikeTouch);
        }

        public void PlayDamageSound(Collision collision)
        {
            if (collision.gameObject.GetComponent<LavaView>())
            {
                PlayLavaTouch();
                return;
            }
            
            if (collision.gameObject.GetComponent<SpikesView>())
            {
                PlaySpikeTouch();
                return;
            }
             
        }
    }
}