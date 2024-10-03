using TMPro;
using UnityEngine;

public class WinnerCheck : MonoBehaviour
{
    [SerializeField] private GameObject _winnerPanel;
    [SerializeField] private TextMeshProUGUI _winnerText;

    private void Start()
    {
        _winnerPanel.SetActive(false);
    }

    public void ShowWinner(string winnerName)
    {
        _winnerPanel.SetActive(true);
        _winnerText.text = $"Winner: {winnerName}";
    }

    public void RestartBattle()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}

