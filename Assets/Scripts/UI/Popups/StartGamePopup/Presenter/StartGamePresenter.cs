using ApplicationEngine.Loading;
using JetBrains.Annotations;
using UnityEngine.Events;

namespace UI.Popups.StartGamePopup
{
    [UsedImplicitly]
    public sealed class StartGamePresenter : IStartGamePresenter
    {
        public UnityAction StartingGameAction { get; }
        
        public StartGamePresenter(LoadingRunner runner)
        {
            StartingGameAction = () => runner.RunLoading(LoadableScenes.MainScene);
        }
    }
}