using Common.Creation;
using UnityEngine;
using Zenject;

namespace UI.Popups.OnLevelCompletePopup
{
    internal sealed class OnLevelCompletePopupInstaller : MonoInstaller
    {
        [SerializeField]
        private OnLevelCompleteView _viewPrefab;
        
        [SerializeField]
        private Transform _container;
        
        public override void InstallBindings()
        {
            BindFactories();
            BindShower();
            BindController();
        }
        
        private void BindFactories()
        {
            Container.Bind<Common.Creation.IFactory<OnLevelCompleteView>>()
                .To<ViewFactory<OnLevelCompleteView>>().AsSingle().WithArguments(_viewPrefab, _container);

            Container.Bind<Common.Creation.IFactory<OnLevelCompletePresenter>>()
                .To<PresenterFactory<OnLevelCompletePresenter>>().AsSingle();
        }

        private void BindShower()
        {
            Container.Bind<OnLevelCompletePopupShower>().AsSingle();
        }

        private void BindController()
        {
            Container.BindInterfacesTo<OnLevelCompletePopupController>().AsCached();
        }
    }
}