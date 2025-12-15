using Common.Creation;
using Common.UI;
using UnityEngine;
using Zenject;

namespace UI.Popups.StartGamePopup
{
    internal sealed class StartGamePopupInstaller : MonoInstaller
    {
        [SerializeField]
        private StartGameView _viewPrefab;
        
        [SerializeField]
        private Transform _container;
        
        public override void InstallBindings()
        {
            BindFactories();
            BindShower();
        }
        
        private void BindFactories()
        {
            Container.Bind<Common.Creation.IFactory<StartGameView>>()
                .To<ViewFactory<StartGameView>>().AsSingle().WithArguments(_viewPrefab, _container);

            Container.Bind<Common.Creation.IFactory<StartGamePresenter>>()
                .To<PresenterFactory<StartGamePresenter>>().AsSingle();
        }

        private void BindShower()
        {
            Container.Bind<IPopupShower>().To<StartGamePopupShower>().AsCached();
        }
    }
}