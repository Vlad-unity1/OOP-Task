using CharacterInfo;
using Restart;
using TMPro;
using UnityEngine;

namespace WinnerWindowUI
{
    public class WinnerCheckUI : MonoBehaviour, IRestartable
    {
        [SerializeField] private GameObject _winnerPanel;
        [SerializeField] private TextMeshProUGUI _winnerText;
        private Character[] _character;

        private void Start()
        {
            _winnerPanel.SetActive(false);
        }

        public void Intialize(Character[] characters)
        {
            _character = characters;
            foreach (Character character in _character)
            {
                character.OnDeath += ShowWinner;
            }
        }

        private void ShowWinner(Character deadCharacter)
        {
            foreach (Character character in _character)
            {
                if (character != deadCharacter)
                {
                    _winnerPanel.SetActive(true);
                    _winnerText.text = $"Winner: {character.Type}";
                    break;
                }
            }
        }

        private void Dispose()
        {
            foreach (Character character in _character)
                character.OnDeath -= ShowWinner;
        }

        public void Restart()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

        public void OnRestartButtonClicked()
        {
            Dispose();
            Restart();
        }
    }
}