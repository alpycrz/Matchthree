using UnityEngine.Events;

namespace Events
{
    public class MenuEvents
    {
        public static UnityAction SettingsBTN;
        public static UnityAction SettingsExitBTN;
        public static UnityAction ScoreboardBTN;
        public static UnityAction ScoreboardExitBTN;
        public static UnityAction StartGameBTN;
        public static UnityAction<float> SoundValueChanged;
        public static UnityAction<float> MusicValueChanged;
    }
}