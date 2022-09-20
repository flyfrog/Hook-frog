using System;
using UnityEngine;
using UnityEngine.UI;

public class UIWinView : MonoBehaviour
{
    [SerializeField] private Transform _winPanelContainer;
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
        _winPanelContainer.gameObject.SetActive(true);
    }
 
    public void HidePanel()
    {
        _winPanelContainer.gameObject.SetActive(false);
    }
}
