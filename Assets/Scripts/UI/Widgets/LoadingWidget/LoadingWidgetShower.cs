using UnityEngine;
using Zenject;

namespace UI.Widgets.LoadingWidget
{
    internal sealed class LoadingWidgetShower : MonoBehaviour
    {
        private LoadingAdapter _adapter;
        
        private Common.Creation.IFactory<LoadingView> _viewFactory;
        private Common.Creation.IFactory<LoadingAdapter, LoadingView> _adapterFactory;

        [Inject]
        internal void Construct(Common.Creation.IFactory<LoadingView> viewFactory,
            Common.Creation.IFactory<LoadingAdapter, LoadingView> adapterFactory)
        {
            _viewFactory = viewFactory;
            _adapterFactory = adapterFactory;
        }
        
        private void OnEnable()
        {
            if (_adapter == null)
            {
                LoadingView view = _viewFactory.Create();
                view.transform.SetAsFirstSibling();
                
                _adapter = _adapterFactory.Create(view);
            }
            
            _adapter.OnEnable();
        }

        private void OnDisable()
        {
            _adapter.OnDisable();
        }
    }
}