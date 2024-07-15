using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu
{
    public class VolumeControl : MonoBehaviour
    {
        public Slider soundSlider;
        public Slider musicSlider;
        public AudioSource musicSource;
        public AudioSource soundSource;

        void Start()
        {
            if (musicSource  != null && musicSlider != null)
            {
                musicSlider.value = musicSource.volume;
            }
            musicSlider.onValueChanged.AddListener(delegate { OnVolumeSliderChanged(); });
        
            if (soundSource != null && soundSlider != null)
            {
                soundSlider.value = soundSource.volume;
            }
            soundSlider.onValueChanged.AddListener(delegate { OnVolumeSliderChanged(); });
        }

        public void OnVolumeSliderChanged()
        {
            if (musicSource != null  &&  musicSlider != null)
            {
                musicSource.volume = musicSlider.value;
            }
            if (soundSource != null && soundSlider != null)
            {
                soundSource.volume = soundSlider.value;
            }
        }

    }
}
