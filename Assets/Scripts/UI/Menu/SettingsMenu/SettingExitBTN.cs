using Events;
using UI.Utils;

namespace UI.Menu.SettingsMenu
{
    public class SettingsExitBTN : UIBTN
    {
        protected override void OnClick() => MenuEvents.SettingsExitBTN?.Invoke();
    }
}

