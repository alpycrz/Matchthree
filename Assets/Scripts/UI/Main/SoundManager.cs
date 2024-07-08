using UnityEngine;

namespace UI.Main
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioClip matchSfx;
        [SerializeField] private AudioClip scoreSfx;
        private AudioSource _audioSource;

        private void Start() => _audioSource = GetComponent<AudioSource>();

        public void MatchSound()
        {
            _audioSource.clip = matchSfx;
            _audioSource.PlayOneShot(matchSfx);
        }

        public void ScoreSound()
        {
            _audioSource.clip = scoreSfx;
            _audioSource.PlayOneShot(scoreSfx);
        }
    }
}