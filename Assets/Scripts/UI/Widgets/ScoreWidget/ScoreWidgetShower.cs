using Common.Creation;
using Common.UI;
using JetBrains.Annotations;

namespace UI.Widgets.ScoreWidget
{
    [UsedImplicitly]
    internal sealed class ScoreWidgetShower<TAdapter> : IWindowShower
    where TAdapter : class
    {
        private readonly IFactory<ScoreView> _viewFactory;
        private readonly IFactory<TAdapter, ScoreView> _adapterFactory;

        internal ScoreWidgetShower(IFactory<ScoreView> viewFactory, IFactory<TAdapter, ScoreView> adapterFactory)
        {
            _viewFactory = viewFactory;
            _adapterFactory = adapterFactory;
        }

        public void Show()
        {
            ScoreView view = _viewFactory.Create();
            _adapterFactory.Create(view);
        }
    }
}