using Events;
using Installers;
using UI.Utils;

namespace UI.Menu.SettingsMenu
{
    public class MusicSlider : UISlider
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            _slider.value = ProjectInstaller.PlayerData.MusicVal;
        }

        protected override void OnValueChanged(float val) => MenuEvents.MusicValueChanged?.Invoke(val);
    }
}