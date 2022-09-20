using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class UIControlJumpView : MonoBehaviour
    {
        [SerializeField] private Button _jumpButton;
        
        public RectTransform GetJumpButtonRectTransform()
        {
            return _jumpButton.GetComponent<RectTransform>();
        }


    }
}