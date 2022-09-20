using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIProgressView : MonoBehaviour
    {
        [SerializeField] private Text _progressText;

        public void SetProgress(int progressArg)
        {
            string progressString = progressArg + "/100";
            _progressText.text = progressString;
        }
    }
}
