using Datas;
using Events;
using Installers;
using UI.Utils;
using UnityEngine;
using Zenject;

namespace UI.Menu.SettingsMenu
{
    public class SoundSlider : UISlider
    {
        [Inject] private MenuEvents MenuEvents { get; set; }
        [Inject] private PlayerData PlayerData { get; set; }

        protected void Start()
        {
            _slider.value = PlayerData.SoundVal;
        }

        protected override void OnValueChanged(float val) => MenuEvents.SoundValueChanged?.Invoke(val);
    }
}
