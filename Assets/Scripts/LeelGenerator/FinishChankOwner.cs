using UnityEngine;

namespace LeelGenerator
{
    public class FinishChankOwner : MonoBehaviour
    {
    

        public GameObject GetFinishChank()
        {
            return  transform.GetChild(0).gameObject;
        }
    }
}
