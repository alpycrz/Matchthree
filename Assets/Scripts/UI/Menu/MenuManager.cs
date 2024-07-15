using Events;
using UI.Utils;
using UnityEngine;

namespace UI.Menu
{
    public class MainMenuManager : EventListenerMono
    {
        [SerializeField] private GameObject _mainMenuPanel;
        [SerializeField] private GameObject _scoreboardPanel;
        [SerializeField] private GameObject _settingsMenuPanel;
        

        private void Start() => SetPanelActive(_mainMenuPanel);

        private void SetPanelActive(GameObject panel)
        {
            _mainMenuPanel.SetActive(_mainMenuPanel == panel);
            _scoreboardPanel.SetActive(_scoreboardPanel == panel);
            _settingsMenuPanel.SetActive(_settingsMenuPanel == panel);
        }

        protected override void RegisterEvents()
        {
            MenuEvents.SettingsBTN += OnSettingsBTN;
            MenuEvents.SettingsExitBTN += OnSettingsExitBTN;
            
            MenuEvents.ScoreboardBTN += OnScoreboardBTN;
            MenuEvents.ScoreboardExitBTN += OnScoreboardExitBTN;
        }

        private void OnSettingsBTN() => SetPanelActive(_settingsMenuPanel);
        private void OnSettingsExitBTN() => SetPanelActive(_mainMenuPanel);
        private void OnScoreboardBTN() => SetPanelActive(_scoreboardPanel);
        private void OnScoreboardExitBTN() => SetPanelActive(_mainMenuPanel);
        protected override void UnRegisterEvents()
        {
            MenuEvents.SettingsBTN -= OnSettingsBTN;
            MenuEvents.SettingsExitBTN -= OnSettingsExitBTN;
            
            MenuEvents.ScoreboardBTN -= OnScoreboardBTN;
            MenuEvents.ScoreboardExitBTN -= OnScoreboardExitBTN;
        }
    }
}