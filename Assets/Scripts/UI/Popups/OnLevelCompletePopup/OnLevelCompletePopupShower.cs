using Common.Creation;
using JetBrains.Annotations;

namespace UI.Popups.OnLevelCompletePopup
{
    [UsedImplicitly]
    internal sealed class OnLevelCompletePopupShower
    {
        private OnLevelCompleteView _view;
        
        private readonly IFactory<OnLevelCompleteView> _viewFactory;
        private readonly IFactory<OnLevelCompletePresenter> _presenterFactory;

        internal OnLevelCompletePopupShower(IFactory<OnLevelCompleteView> viewFactory,
            IFactory<OnLevelCompletePresenter> presenterFactory)
        {
            _viewFactory = viewFactory;
            _presenterFactory = presenterFactory;
        }

        public void Show()
        {
            OnLevelCompletePresenter presenter = default;
            
            if (_view == null)
            {
                presenter = _presenterFactory.Create();
                _view = _viewFactory.Create();
            }
            
            _view.Show(presenter);
        }

        public void Hide()
        {
            _view?.Hide();
        }
    }
}