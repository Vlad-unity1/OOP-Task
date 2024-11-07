using CharacterInfo;
using UnityEngine.Events;
using WinnerModelUI;
using WinnerViewUI;

namespace WinnerControllerUI
{
    public class WinnerController
    {
        private readonly WinnerView _winnerView;
        private readonly WinnerModel _winnerModel;

        public WinnerController(WinnerModel winnerModel, WinnerView winnerView)
        {
            _winnerModel = winnerModel;
            _winnerView = winnerView;
            _winnerModel.OnWinnerDeclared += OnWinnerDeclared;
        }

        private void OnWinnerDeclared(Character winner)
        {
            _winnerView.ShowWinner(winner.Type.ToString());
            Dispose();
        }

        private void Dispose()
        {
            _winnerModel.OnWinnerDeclared -= OnWinnerDeclared;
            _winnerModel.Dispose();
        }
    }
}
