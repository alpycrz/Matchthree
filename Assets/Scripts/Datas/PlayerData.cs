using UnityEngine;
using Events;

namespace Datas
{
    public class PlayerData
    {
        public float SoundVal => _soundVal;
        private const string SoundPrefKey = "Sound";
        private float _soundVal;
        
        public float MusicVal => _musicVal;
        private const string MusicPrefKey = "Music";
        private float _musicVal;

        public PlayerData()
        {
            _soundVal = PlayerPrefs.GetFloat(SoundPrefKey);
            _musicVal = PlayerPrefs.GetFloat(MusicPrefKey);
            
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            MenuEvents.SoundValueChanged += OnSoundValueChanged;
            MenuEvents.MusicValueChanged += OnMusicValueChanged;
        }

        private void OnSoundValueChanged(float soundVal)
        {
            _soundVal = soundVal;
            PlayerPrefs.SetFloat(SoundPrefKey, _soundVal);
        }
        private void OnMusicValueChanged(float musicVal)
        {
            _musicVal = musicVal;
            PlayerPrefs.SetFloat(MusicPrefKey, _musicVal);
        }
        
    }
}