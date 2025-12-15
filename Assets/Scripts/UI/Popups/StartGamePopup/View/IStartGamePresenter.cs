using UnityEngine.Events;

namespace UI.Popups.StartGamePopup
{
    public interface IStartGamePresenter
    {
        UnityAction StartingGameAction { get; }
    }
}