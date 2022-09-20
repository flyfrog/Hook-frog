using System;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOverView : MonoBehaviour
{
    [SerializeField] private Transform _gameOverPanelContainer;
    [SerializeField] private Button _restartButton;
    public event Action onClickRestartGameButtonEvent; 

    private void Start()
    {
         _restartButton.onClick.AddListener( OnClickRestartGame);
    }

    private void OnClickRestartGame()
    {
        onClickRestartGameButtonEvent?.Invoke();
    }
    
    
    public void ShowPanel()
    {
        _gameOverPanelContainer.gameObject.SetActive(true);
    }
 
    public void HidePanel()
    {
        _gameOverPanelContainer.gameObject.SetActive(false);
    }

}
