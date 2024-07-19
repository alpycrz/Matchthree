using System;
using Settings;
using Sirenix.OdinInspector;
using TMPro;
using UI.Main;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Components
{
    public class GameManager : SerializedMonoBehaviour
    {
        [Inject] private ProjectSettings ProjectSettings { get; set; }
        [SerializeField] private Image _timeBar;
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private TextMeshProUGUI _highScoreText;
        [SerializeField] private TextMeshProUGUI _currentScoreText;
        [SerializeField] private GameObject _gameOverPanel;
        private float _currTime;
        private int _highScore;
        private bool _isGameOver = false;
        private Settings _mySettings;
        private void Awake() => _mySettings = ProjectSettings.GameManagerSettings;
        private void Start()
        {
            StartNewGame();
            LoadSettings();
            _highScore = PlayerPrefs.GetInt("HighScore", 0); 
            UpdateHighScore();
        }

        private void Update()
        {
            if (!_isGameOver)
            {
                _currTime -= Time.deltaTime;
                UpdateTimeBar();

                if (_currTime <= 0) GameOver();
            }
        }

        private void StartNewGame()
        {
            _currTime = _mySettings.InitTime;
            _isGameOver = false;
            _gameOverPanel.SetActive(false);
            UpdateHighScore();
        }

        public void AddMatchScore(int matchScore)
        {
            PlayerScoreTMP.GetCurrentScore();
            _currTime += _mySettings.TimeMulti;
            _currTime = Mathf.Min(_currTime, _mySettings.InitTime);
            UpdateTimeBar();
        }

        private void GameOver()
        {
            _isGameOver = true;
            _gameOverPanel.SetActive(true);
            
            int currScore = PlayerScoreTMP.GetCurrentScore();
            _currentScoreText.text = $"Score: {currScore}";
            if (currScore > _highScore)
            {
                _highScore = currScore;
                PlayerPrefs.SetInt("HighScore", _highScore);
                PlayerPrefs.Save();
                UpdateHighScore();
            }
            _highScoreText.text = $"High Score: {_highScore}"; 
        }

        private void UpdateTimeBar()
        {
            _timerText.text = $"{_currTime:F1}";
            _timeBar.fillAmount = _currTime / _mySettings.InitTime;
            
            float normalizedTime = _currTime / _mySettings.InitTime;
            _timeBar.color = Color.Lerp(Color.red, Color.green, normalizedTime);
        }
        
        private void UpdateHighScore()
        {
            PlayerPrefs.GetInt("HighScore", _highScore);
            _highScoreText.text = $"High Score: {_highScore}";
        }

        private void LoadSettings()
        {
            _mySettings = Resources.Load<ProjectSettings>(EnvVar.ProjectSettingsPath).GameManagerSettings;
        }
        
        [Serializable] public class Settings
        {
            [SerializeField] private float _initTime = 20f;
            [SerializeField] private float _timeMulti = 1.5f;
            public float InitTime => _initTime;
            public float TimeMulti => _timeMulti;
        }
    }
}