using UnityEngine;

namespace LeelGenerator
{
    public class ChanksOwner : MonoBehaviour
    {
        private GameObject[] _chankArray;

        private void Awake()
        {
            DisableSourceChank();
            _chankArray = MakeChanksArray();
        }

        private GameObject[] MakeChanksArray()
        {
            int childCount = transform.childCount;
            GameObject[] chanksArray = new GameObject[childCount];

            for (int i = 0; i < childCount; i++)
            {
                chanksArray[i] = transform.GetChild(i).gameObject;
            }

            return chanksArray;
        }

        private void DisableSourceChank()
        {  
            int childCount = transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        public GameObject[] GetChanksArray()
        {
            return _chankArray;
        }
  
    }
}
