using CharacterInfo;
using Restart;
using Spawn;
using UnityEngine;
using WinnerModelUI;
using WinnerViewUI;

namespace WinnerControllerUI
{
    public class WinnerController : MonoBehaviour
    {
        [SerializeField] private WinnerView _winnerView;

        private WinnerModel _winnerModel;
        private IRestartable _gameRestarter;

        public void Initialize(Spawner spawner, IRestartable gameRestarter)
        {
            _gameRestarter = gameRestarter;
            _winnerModel = new WinnerModel(spawner);
            _winnerModel.OnWinnerDeclared += OnWinnerDeclared;
        }

        private void OnWinnerDeclared(Character winner)
        {
            _winnerView.ShowWinner(winner.Type.ToString());
        }

        private void Dispose()
        {
            _winnerModel.OnWinnerDeclared -= OnWinnerDeclared;
        }

        public void OnRestartButtonClicked()
        {
            _gameRestarter.Restart();
            Dispose();
            _winnerModel.Dispose();
        }
    }
}
