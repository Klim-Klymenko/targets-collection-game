using UnityEngine.Events;

namespace UI.Popups.OnLevelCompletePopup
{
    public interface IOnLevelCompletePresenter
    {
        UnityAction ReloadLevelAction { get; }
        string LevelDuration { get; }
        string Score { get; }
    }
}