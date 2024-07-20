using UnityEngine.Events;

namespace Events
{
    public class MenuEvents
    {
        public UnityAction SettingsBTN;
        public UnityAction SettingsExitBTN;
        public UnityAction ScoreboardBTN;
        public UnityAction ScoreboardExitBTN;
        public UnityAction StartGameBTN;
        public UnityAction<float> SoundValueChanged;
        public UnityAction<float> MusicValueChanged;
    }
}