using ApplicationEngine.GameCycle;
using Common.Creation;
using UnityEngine;
using Zenject;

namespace Common.UI
{
    public class WidgetInstaller<TView, TAdapter> : MonoInstaller
        where TView : MonoBehaviour
        where TAdapter : class, IGameListener
    {
        [SerializeField]
        private TView _prefab;
        
        [SerializeField]
        private Transform _canvas;
        
        public override void InstallBindings()
        {
            BindFactories();
            BindShower();
        }
        
        private void BindFactories()
        {
            Container.Bind<Creation.IFactory<TView>>().To<ViewFactory<TView>>()
                .AsSingle().WithArguments(_prefab, _canvas);

            Container.Bind<Creation.IFactory<TAdapter, TView>>()
                .To<PresenterFactory<TAdapter, TView>>().AsSingle();
        }

        private void BindShower()
        {
            Container.Bind<IWindowShower>().To<WindowShower<TView, TAdapter>>().AsCached();
        }
    }
}