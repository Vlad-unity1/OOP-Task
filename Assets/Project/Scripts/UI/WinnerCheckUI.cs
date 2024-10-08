using TMPro;
using UnityEngine;

namespace WinnerWindowUI
{
    public class WinnerCheckUI : MonoBehaviour
    {
        [SerializeField] private GameObject _winnerPanel;
        [SerializeField] private TextMeshProUGUI _winnerText;

        private void Start()
        {
            _winnerPanel.SetActive(false);
        }

        public void ShowWinner(CharacterType type)
        {
            _winnerPanel.SetActive(true);
            _winnerText.text = $"Winner: {type}";
        }

        public void RestartBattle()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}

