using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class BlockerRaycastForUI : MonoBehaviour
    {
        [Header("Drag UI element for cheking raycast")] [SerializeField]
        private List<RectTransform> _listRectTransormAreaForCheking = new List<RectTransform>();


        public bool CheckThisIsItRestrectArea(Vector2 clickPositionArg)
        {
            foreach (var rectTransformElement in _listRectTransormAreaForCheking)
            {
                Vector2 pivot = rectTransformElement.pivot;
                Vector2 rectSize = rectTransformElement.lossyScale * rectTransformElement.rect.size;

                float rectXPos = rectTransformElement.position.x;
                float rectYPos = rectTransformElement.position.y;

                rectXPos -= rectSize.x * pivot.x;
                rectYPos -= rectSize.y * pivot.y;

                Rect checkAreaRealRect = new Rect(rectXPos, rectYPos, rectSize.x, rectSize.y);

                if (checkAreaRealRect.Contains(clickPositionArg))
                    return true;
            }

            return false;
        }
    }
}