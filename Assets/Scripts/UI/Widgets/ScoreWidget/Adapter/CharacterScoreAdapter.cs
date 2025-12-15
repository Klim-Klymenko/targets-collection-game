using ApplicationEngine.GameCycle;
using Common.UI;
using GameEngine.Character;
using JetBrains.Annotations;

namespace UI.Widgets.ScoreWidget
{
    [UsedImplicitly]
    public sealed class CharacterScoreAdapter : IInitializable, IFinishable
    {
        private readonly ScoreCounter _counter;
        private readonly ScoreView _view;

        public CharacterScoreAdapter(ScoreCounter counter, ScoreView view)
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
            _view.UpdateScoreText(score.ToString());
        }
    }
}