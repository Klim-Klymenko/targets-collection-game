using JetBrains.Annotations;
using Zenject;

namespace UI.Widgets.LoadingWidget
{
    [UsedImplicitly]
    public sealed class LoadingAdapterFactory : Common.Creation.IFactory<LoadingAdapter, LoadingView>
    {
        private readonly DiContainer _diContainer;

        public LoadingAdapterFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        LoadingAdapter Common.Creation.IFactory<LoadingAdapter, LoadingView>.Create(LoadingView view)
        {
            object[] args = { view };
            return _diContainer.Instantiate<LoadingAdapter>(args);
        }
    }
}