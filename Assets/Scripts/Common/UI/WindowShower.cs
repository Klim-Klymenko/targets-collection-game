using ApplicationEngine.GameCycle;
using Common.Creation;
using JetBrains.Annotations;
using UnityEngine;

namespace Common.UI
{
    [UsedImplicitly]
    public sealed class WindowShower<TView, TAdapter> : IWindowShower
        where TView : MonoBehaviour
        where TAdapter : class, IGameListener
    {
        private readonly IFactory<TView> _viewFactory;
        private readonly IFactory<TAdapter, TView> _adapterFactory;

        public WindowShower(IFactory<TView> viewFactory, IFactory<TAdapter, TView> adapterFactory)
        {
            _viewFactory = viewFactory;
            _adapterFactory = adapterFactory;
        }

        void IWindowShower.Show()
        {
            TView view = _viewFactory.Create();
            _adapterFactory.Create(view);
        }
    }
}