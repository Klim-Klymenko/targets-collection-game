using ApplicationEngine.GameCycle;
using GameEngine.ItemFeature;
using JetBrains.Annotations;

namespace UI.Popups.OnLevelCompletePopup
{
    [UsedImplicitly]
    internal sealed class OnLevelCompletePopupController : IInitializable, IFinishable
    {
        private readonly ItemsCounter _counter;
        private readonly OnLevelCompletePopupShower _shower;

        internal OnLevelCompletePopupController(ItemsCounter counter, OnLevelCompletePopupShower shower)
        {
            _counter = counter;
            _shower = shower;
        }

        void IInitializable.OnInitialize()
        {
            _counter.OnItemsRunOut += ShowPopup;
        }

        void IFinishable.OnFinish()
        {
            _counter.OnItemsRunOut -= ShowPopup;
        }

        private void ShowPopup()
        {
            _shower.Show();
        }
    }
}