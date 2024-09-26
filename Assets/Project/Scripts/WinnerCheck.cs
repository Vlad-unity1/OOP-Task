using CharacterAttack;
using TMPro;
using UnityEngine;

public class WinnerCheck : MonoBehaviour
{
    public GameObject winnerPanel;           
    public TextMeshProUGUI winnerText;       

    private void Start()
    {
        winnerPanel.SetActive(false);
    }

    public void ShowWinner(string winnerName)
    {
        winnerPanel.SetActive(true);
        winnerText.text = $"Winner: {winnerName}";
    }

    public void RestartBattle()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}

