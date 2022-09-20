using Damage;
using Managers;
using Sound;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerCollisionController : MonoBehaviour
    {
        private const float _timeDelayGameOverAfterDeathHit = 0.5f;
        private PlayerView _playerView;
        private GameOverManager _gameOverManager;
        private EnvironmenttSound _environmentSound;
        private PlayerSound _playerSound;
        private PlayerParticleSystemSpawner _playerParticleSystemSpawner;
        private bool _isLife = true;

        [Inject]
        private void Construction(PlayerView playerViewArg, GameOverManager gameOverManagerArg, EnvironmenttSound environmentSoundArg,
            PlayerSound playerSoundArg, PlayerParticleSystemSpawner playerParticleSystemSpawnerArg)
        {
            _playerView = playerViewArg;
            _gameOverManager = gameOverManagerArg;
            _environmentSound = environmentSoundArg;
            _playerSound = playerSoundArg;
            _playerParticleSystemSpawner = playerParticleSystemSpawnerArg;
        }

        private void OnEnable()
        {

            _playerView.OnCollisionEnterEvent += CheckCollisionType;
        }

        private void OnDisable()
        {
            _playerView.OnCollisionEnterEvent -= CheckCollisionType;
        }

        private void CheckCollisionType(Collision collision)
        {
            if (collision.gameObject.GetComponent<DamageCarrier>())
            {
                HitDamage(collision);
            }
            else
            {
                HitWall();
            }
        }

        private void HitWall()
        {
            _environmentSound.PlayWallHit();
        }

        private void HitDamage(Collision collision)
        {
            _environmentSound.PlayDamageSound(collision);
            _playerParticleSystemSpawner.SpawnDeathParticleSystem(_playerView.gameObject.transform.position);
            _playerSound.PlayDeathCry();

            if (_isLife)
            {
                _isLife = false;
                Invoke(nameof(GameOver), _timeDelayGameOverAfterDeathHit);
            }
        }

        private void GameOver()
        {
            _gameOverManager.GameOver();
        }


    }
}
