using ApplicationEngine.GameCycle;
using Common.UI;
using GameEngine.Character;
using JetBrains.Annotations;

namespace UI.Widgets.ScoreWidget
{
    [UsedImplicitly]
    internal sealed class ScoreAdapter : IInitializable, IFinishable
    {
        private readonly ScoreCounter _counter;
        private readonly BasicWidgetView _view;

        internal ScoreAdapter(ScoreCounter counter, BasicWidgetView view)
        {
            _counter = counter;
            _view = view;
        }

        void IInitializable.OnInitialize()
        {
            _counter.OnScoreChanged += UpdateScore;
        }

        void IFinishable.OnFinish()
        {
            _counter.OnScoreChanged -= UpdateScore;
        }
        
        private void UpdateScore(int score)
        {
            _view.UpdateText($"Score: {score}");
        }
    }
}