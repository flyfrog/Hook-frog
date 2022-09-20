using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIMenuView : MonoBehaviour
    {
        [SerializeField] private Transform _menuPanelContainer;
        [SerializeField] private Button _returnInGameButton;
        [SerializeField] private Button _restartGameButton;
        [SerializeField] private Button _openMenuButton;
        
        public event Action onClickButtonBackInGameEvent;
        public event Action onClickButtonRestartGameEvent;
        public event Action onClickButtonOpenMenuEvent;
        
        private void Start()
        {
            _restartGameButton.onClick.AddListener( OnClickRestartGame);
            _returnInGameButton.onClick.AddListener( OnClickReturnInGame);
            _openMenuButton.onClick.AddListener(OnClickOpenMenu);
        }

        private void OnClickOpenMenu()
        {
            onClickButtonOpenMenuEvent?.Invoke();
        }

        private void OnClickRestartGame()
        {
            onClickButtonRestartGameEvent?.Invoke();
        }


        private void OnClickReturnInGame()
        {
            onClickButtonBackInGameEvent?.Invoke();
        }


        public void ShowPanel()
        {
            _menuPanelContainer.gameObject.SetActive(true);
        }
 
        public void HidePanel()
        {
            _menuPanelContainer.gameObject.SetActive(false);
        }

        
    }
}
