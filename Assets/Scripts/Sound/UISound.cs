using UnityEngine;

namespace Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class UISound : MonoBehaviour
    {
        [SerializeField] private AudioClip _click;
        [SerializeField] private AudioClip _openPanel;
    
        private AudioSource _audioSource;
        
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void  PlayClick()
        {
            _audioSource.PlayOneShot(_click);
        }
    
        public void PlayOpenPanel()
        {
            _audioSource.PlayOneShot(_openPanel);
        }
    }
}