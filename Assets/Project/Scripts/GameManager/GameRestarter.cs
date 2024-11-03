using Restart;

namespace GameRestart
{
    public class GameRestarter : IRestartable
    {
        public void Restart()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
            );
        }
    }
}