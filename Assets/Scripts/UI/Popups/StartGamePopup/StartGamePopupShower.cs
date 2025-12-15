using Common.Creation;
using Common.UI;
using JetBrains.Annotations;

namespace UI.Popups.StartGamePopup
{
    [UsedImplicitly]
    public sealed class StartGamePopupShower : IPopupShower
    {
        private StartGameView _view;
        
        private readonly IFactory<StartGameView> _viewFactory;
        private readonly IFactory<StartGamePresenter> _presenterFactory;

        internal StartGamePopupShower(IFactory<StartGameView> viewFactory,
            IFactory<StartGamePresenter> presenterFactory)
        {
            _viewFactory = viewFactory;
            _presenterFactory = presenterFactory;
        }

        public void Show()
        {
            StartGamePresenter presenter = default;
            
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