using TMPro;
using UnityEngine;

namespace WinnerViewUI
{
    public class WinnerView : MonoBehaviour
    {
        [SerializeField] private GameObject _winnerPanel;
        [SerializeField] private TextMeshProUGUI _winnerText;

        private void Start()
        {
            Hide();
        }

        public void ShowWinner(string winnerType)
        {
            _winnerPanel.SetActive(true);
            _winnerText.text = $"Winner: {winnerType}";
        }

        private void Hide()
        {
            _winnerPanel.SetActive(false);
        }
    }
}
