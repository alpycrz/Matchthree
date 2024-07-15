using Events;
using Installers;
using UI.Utils;
using UnityEngine;

namespace UI.Menu.SettingsMenu
{
    public class SoundSlider : UISlider
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            _slider.value = ProjectInstaller.PlayerData.SoundVal;
        }

        protected override void OnValueChanged(float val) => MenuEvents.SoundValueChanged?.Invoke(val);
    }
}
