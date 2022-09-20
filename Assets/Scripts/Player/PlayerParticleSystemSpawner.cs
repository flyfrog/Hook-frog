using UnityEngine;

namespace Player
{
    public class PlayerParticleSystemSpawner: MonoBehaviour
    {
        [SerializeField] private ParticleSystem _prefabDeathFX; 

        public void SpawnDeathParticleSystem(Vector3 positionPlayer)
        {
            Instantiate(_prefabDeathFX,positionPlayer,Quaternion.identity);
        }

    }
}