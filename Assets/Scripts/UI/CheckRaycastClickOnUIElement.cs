using UnityEngine;

namespace UI
{
    public class CheckRaycastClickOnUIElement
    {
        public bool CheckContains(Vector2 clickPositionArg, RectTransform rectTransformElementArg)
        {
            Vector2 pivot = rectTransformElementArg.pivot;
            Vector2 rectSize = rectTransformElementArg.lossyScale * rectTransformElementArg.rect.size;

            float rectXPos = rectTransformElementArg.position.x;
            float rectYPos = rectTransformElementArg.position.y;

            rectXPos -= rectSize.x * pivot.x;
            rectYPos -= rectSize.y * pivot.y;

            Rect checkAreaRealRect = new Rect(rectXPos, rectYPos, rectSize.x, rectSize.y);

            return checkAreaRealRect.Contains(clickPositionArg);
        }
    }
}