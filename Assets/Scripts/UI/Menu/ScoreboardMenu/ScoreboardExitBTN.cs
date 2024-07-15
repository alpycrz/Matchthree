using Events;
using UI.Utils;

namespace UI.Menu.SettingsMenu
{
    public class ScoreboardExitBTN : UIBTN
    {
        protected override void OnClick() => MenuEvents.ScoreboardExitBTN?.Invoke();
    }
}