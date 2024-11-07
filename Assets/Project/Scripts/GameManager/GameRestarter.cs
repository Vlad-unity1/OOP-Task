using Restart;
using UnityEngine;

namespace GameRestart
{
    public class GameRestarter : MonoBehaviour, IRestartable
    {
        public void Restart()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
            );
        }
    }
}