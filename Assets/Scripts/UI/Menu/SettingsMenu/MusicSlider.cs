using Datas;
using Events;
using Installers;
using UI.Utils;
using Zenject;

namespace UI.Menu.SettingsMenu
{
    public class MusicSlider : UISlider
    {
        [Inject] private MenuEvents MenuEvents { get; set; }
        [Inject] private PlayerData PlayerData { get; set; }

        protected void Start()
        {
            _slider.value = PlayerData.MusicVal;
        }

        protected override void OnValueChanged(float val) => MenuEvents.MusicValueChanged?.Invoke(val);
    }
}