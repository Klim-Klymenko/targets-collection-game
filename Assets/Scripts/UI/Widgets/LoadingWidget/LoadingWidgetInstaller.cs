using Common.Creation;
using UnityEngine;
using Zenject;

namespace UI.Widgets.LoadingWidget
{
    internal sealed class LoadingWidgetInstaller : MonoInstaller
    {
        [SerializeField]
        private LoadingView _viewPrefab;
        
        [SerializeField]
        private Transform _container;
        
        public override void InstallBindings()
        {
            BindFactories();
        }
        
        private void BindFactories()
        {
            Container.Bind<Common.Creation.IFactory<LoadingView>>().To<ViewFactory<LoadingView>>()
                .AsSingle().WithArguments(_viewPrefab, _container);

            Container.Bind<Common.Creation.IFactory<LoadingAdapter, LoadingView>>()
                .To<LoadingAdapterFactory>().AsSingle();
        }
    }
}