using ApplicationEngine.Loading;
using Common.Time;
using GameEngine.Character;
using JetBrains.Annotations;
using UnityEngine.Events;

namespace UI.Popups.OnLevelCompletePopup
{
    [UsedImplicitly]
    public sealed class OnLevelCompletePresenter : IOnLevelCompletePresenter
    {
        public UnityAction ReloadLevelAction { get; }
        public string LevelDuration { get; }
        public string Score { get; }

        internal OnLevelCompletePresenter(LoadingRunner runner, TickTimer timer, ScoreCounter counter)
        {
            ReloadLevelAction = runner.ReloadScene;
            LevelDuration = $"Time spent: {timer.ElapsedTime}";
            Score = $"Final score: {counter.Score}";
        }
    }
}