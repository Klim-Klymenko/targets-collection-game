using Common.Creation;
using Common.UI;
using UnityEngine;
using Zenject;

namespace UI.Widgets.ScoreWidget
{
    internal sealed class MainScoreWidgetInstaller : MonoInstaller
    {
        [SerializeField]
        private ScoreView _viewPrefab;
        
        [SerializeField]
        private Transform _container;
        
        public override void InstallBindings()
        {
            BindFactories();
            BindShower();
        }
        
        private void BindFactories()
        {
            Container.Bind<Common.Creation.IFactory<ScoreView>>().To<ViewFactory<ScoreView>>()
                .AsSingle().WithArguments(_viewPrefab, _container);

            Container.Bind<Common.Creation.IFactory<MainScoreAdapter, ScoreView>>()
                .To<PresenterFactory<MainScoreAdapter, ScoreView>>().AsSingle();
        }

        private void BindShower()
        {
            Container.Bind<IWindowShower>().To<ScoreWidgetShower<MainScoreAdapter>>().AsCached();
        }
    }
}