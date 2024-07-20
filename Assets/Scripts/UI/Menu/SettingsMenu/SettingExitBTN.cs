using Events;
using UI.Utils;
using Zenject;

namespace UI.Menu.SettingsMenu
{
    
    public class SettingsExitBTN : UIBTN
    {
        [Inject] private MenuEvents MenuEvents { get; set; }

        protected override void OnClick() => MenuEvents.SettingsExitBTN?.Invoke();
    }
}

