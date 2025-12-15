using ApplicationEngine.GameCycle;
using Common.Creation;
using Common.UI;
using UnityEngine;
using Zenject;

namespace UI.Widgets.ScoreWidget
{
    internal sealed class CharacterScoreWidgetInstaller : MonoInstaller
    {
        [SerializeField]
        private SceneContext _sceneContext;
        
        [SerializeField]
        private ScoreView _viewPrefab;
        
        [SerializeField]
        private Transform _container;

        private IWindowShower _shower;
        
        public override void InstallBindings()
        {
            _sceneContext.PostResolve += ShowWidget;
        }
        
        private void ShowWidget()
        {
            GameCycleManager gameCycleManager = Container.Resolve<GameCycleManager>();
            
            PresenterFactory<CharacterScoreAdapter, ScoreView> presenterFactory = new(gameCycleManager, Container);
            ViewFactory<ScoreView> viewFactory = new(_viewPrefab, _container, Container);
            
            ScoreWidgetShower<CharacterScoreAdapter> shower = new(viewFactory, presenterFactory);
            shower.Show();
            
            _sceneContext.PostResolve -= ShowWidget;
        }
    }
}