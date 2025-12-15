using Lean.Gui;
using UnityEngine;

namespace UI.Popups.StartGamePopup
{
    public sealed class StartGameView : MonoBehaviour
    {
        [SerializeField] 
        private LeanButton _button;

        private IStartGamePresenter _presenter;
        
        public void Show(IStartGamePresenter presenter)
        {
            _presenter = presenter;
            _button.OnClick.AddListener(_presenter.StartingGameAction);
        }

        public void Hide()
        {
            _button.OnClick.RemoveListener(_presenter.StartingGameAction);
        }
    }
}