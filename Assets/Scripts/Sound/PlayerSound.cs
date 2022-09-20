using UnityEngine;

namespace Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayerSound : MonoBehaviour
    {
        [SerializeField] private AudioClip _jump;
        [SerializeField] private AudioClip _deathCry;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        /*
    public void PlaySoundHit(Collision collision)
    {
        float impulse = collision.impulse.magnitude / Time.fixedDeltaTime;

        if (impulse < _porogSoundForce)
            return;

        float normalizedImpulse = Mathf.InverseLerp(_porogSoundForce, 1000, impulse);
        float volome = normalizedImpulse;
        float pitch = Mathf.Lerp(0.8f, 1.1f, normalizedImpulse);

        _audioSource.pitch = pitch;

        int randomClip = Random.Range(0, _audioHit.Length);
        _audioSource.PlayOneShot(_audioHit[randomClip]);
    }

*/
        public void PlayJump()
        {
            _audioSource.PlayOneShot(_jump);
        }
        
        
        public void PlayDeathCry()
        {
            _audioSource.PlayOneShot(_deathCry);
        }
        
    }
}