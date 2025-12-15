using Lean.Gui;
using UnityEngine;

namespace UI.Popups.OnLevelCompletePopup
{
    public sealed class OnLevelCompleteView : MonoBehaviour
    {
        [SerializeField]
        private LeanButton _restartButton;

        private IOnLevelCompletePresenter _presenter;
        
        public void Show(IOnLevelCompletePresenter presenter)
        {
            _presenter = presenter;

            Debug.Log(presenter.LevelDuration);
            Debug.Log(presenter.Score);
            
            _restartButton.OnClick.AddListener(presenter.ReloadLevelAction);
        }

        public void Hide()
        {
            _restartButton.OnClick.RemoveListener(_presenter.ReloadLevelAction);
        }
    }
}