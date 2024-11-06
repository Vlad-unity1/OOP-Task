using CharacterInfo;
using Restart;
using WinnerModelUI;
using WinnerViewUI;

namespace WinnerControllerUI
{
    public class WinnerController
    {
        private readonly WinnerView _winnerView;
        private readonly WinnerModel _winnerModel;
        private readonly IRestartable _gameRestarter;

        public WinnerController(IRestartable gameRestarter, WinnerModel winnerModel, WinnerView winnerView)
        {
            _gameRestarter = gameRestarter;
            _winnerModel = winnerModel;
            _winnerView = winnerView;
            _winnerModel.OnWinnerDeclared += OnWinnerDeclared;
        }

        private void OnWinnerDeclared(Character winner)
        {
            _winnerView.ShowWinner(winner.Type.ToString());
        }

        private void Dispose()
        {
            _winnerModel.OnWinnerDeclared -= OnWinnerDeclared;
            _winnerModel.Dispose();
        }

        public void OnRestartButtonClicked()
        {
            _gameRestarter.Restart();
            Dispose();
        }
    }
}
