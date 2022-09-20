using UnityEngine.SceneManagement;

namespace Managers
{
    public class RestartManager
    {
        public void RestartGame()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}