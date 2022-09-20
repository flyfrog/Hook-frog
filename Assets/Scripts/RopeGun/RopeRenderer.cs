using UnityEngine;

namespace RopeGun
{
    public class RopeRenderer : MonoBehaviour
    {

        public LineRenderer lineRenderer;
        public int segmentsRope = 10;
    
        public void DrawRope(Vector3 a, Vector3 b, float length)
        {
            lineRenderer.enabled = true;
            float interpoland = Vector3.Distance(a, b) / length;
            float offset = Mathf.Lerp(length / 2f, 0f, interpoland);

            Vector3 aDown = a + Vector3.down * offset;
            Vector3 bDown = b + Vector3.down * offset;
        
            lineRenderer.positionCount = segmentsRope + 1;

            for (int i = 0; i < segmentsRope + 1; i++)
            {
                float bezerLerp = (float)i / segmentsRope;
                Vector3 newRopepoint = Bezier.GetPoint(a, aDown, bDown, b, bezerLerp);
                lineRenderer.SetPosition(i, newRopepoint);
            }
        }

        public void HideRope(){
            lineRenderer.enabled = false; 
        }
    
    }
}
