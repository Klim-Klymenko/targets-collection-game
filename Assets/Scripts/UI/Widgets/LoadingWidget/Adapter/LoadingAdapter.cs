using ApplicationEngine.Loading;
using JetBrains.Annotations;

namespace UI.Widgets.LoadingWidget
{
    [UsedImplicitly]
    public sealed class LoadingAdapter
    {
        private const float InitialProgress = 0.0f;
        private const byte DecimalToPercentage = 100;
        
        private readonly LoadingView _view;
        private readonly Loader _loader;

        public LoadingAdapter(LoadingView view, Loader loader)
        {
            _view = view;
            _loader = loader;
        }

        public void OnEnable()
        {
            _loader.OnLoadingStarted += Show;
            _loader.OnLoadingProgressed += UpdateProgress;
            _loader.OnLoadingFinished += Hide;
        }

        public void OnDisable()
        {
            _loader.OnLoadingStarted -= Show;
            _loader.OnLoadingProgressed -= UpdateProgress;
            _loader.OnLoadingFinished -= Hide;
        }

        private void Show()
        {
            _view.Show();
        }

        private void Hide()
        {
            _view.Hide();
            UpdateProgress(InitialProgress);
        }
        
        private void UpdateProgress(float progress)
        {
            int progressInPercentage = (int) (progress * DecimalToPercentage);
            _view.UpdateProgressText($"{progressInPercentage}%");
            
            _view.UpdateProgressBar(progress);
        }
    }
}