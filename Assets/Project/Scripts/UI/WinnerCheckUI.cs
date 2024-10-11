using Spawn;
using TMPro;
using UnityEngine;

namespace WinnerWindowUI
{
    public class WinnerCheckUI : UIView
    {
        [SerializeField] private GameObject _winnerPanel;
        [SerializeField] private TextMeshProUGUI _winnerText;
        public static WinnerCheckUI Instance { get; private set; }

        private void Start()
        {
            Instance = this;
            _winnerPanel.SetActive(false);
        }

        public override void ShowWinner(CharacterType type)
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

