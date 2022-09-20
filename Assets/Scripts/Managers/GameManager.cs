using System.Security.Cryptography.X509Certificates;
using UI;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class GameManager: IInitializable
    {

        private PauseManager _pauseManager;
        
        [Inject]
        public GameManager( PauseManager pauseManagerArg)
        {
            _pauseManager = pauseManagerArg;
        }
        
        public void Initialize()
        {
         _pauseManager.PauseOn();
        }
    }
}