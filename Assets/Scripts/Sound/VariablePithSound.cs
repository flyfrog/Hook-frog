using UnityEngine;

public class VariablePithSound
{
    private AudioSource _audioSource;
    private float _minPitch;
    private float _maxPitch;
    
    public VariablePithSound(AudioSource audioSourceArg, float minPitchArg, float maxPitchArg)
    {
        _audioSource = audioSourceArg;
        _minPitch = minPitchArg;
        _maxPitch = maxPitchArg;
    }

    public void Play(AudioClip audioClipArg)
    {
        _audioSource.pitch  =  Random.Range(_minPitch, _maxPitch);
        _audioSource.PlayOneShot(audioClipArg);
    }
    
}