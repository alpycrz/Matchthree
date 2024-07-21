using Components;
using Datas;
using Events;
using Settings;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Installers
{
    public class ProjectInstaller : MonoInstaller<ProjectInstaller>
    {
        private GameManager _gameManager;
        private ProjectEvents _projectEvents;
        private InputEvents _inputEvents;
        private GridEvents _gridEvents;
        private ProjectSettings _projectSettings;

        private MenuEvents _menuEvents;
        private MainUIEvents _mainUIEvents;
        private PlayerData _playerData;

        public override void InstallBindings()
        {
            InstallEvents();
            InstallData();
            InstallSettings();
        }

        private void InstallSettings()
        {
            _projectSettings = Resources.Load<ProjectSettings>(EnvVar.ProjectSettingsPath);
            Container.BindInstance(_projectSettings).AsSingle();
        }

        private void InstallEvents()
        {
            _projectEvents = new ProjectEvents();
            Container.BindInstance(_projectEvents).AsSingle();

            _inputEvents = new InputEvents();
            Container.BindInstance(_inputEvents).AsSingle();

            _gridEvents = new GridEvents();
            Container.BindInstance(_gridEvents).AsSingle();

            _menuEvents = new MenuEvents();
            Container.BindInstance(_menuEvents).AsSingle();

            _mainUIEvents = new MainUIEvents();
            Container.BindInstance(_mainUIEvents).AsSingle();
        }

        private void InstallData()
        {
            _playerData = new PlayerData();

            Container.BindInstance(_playerData).AsSingle();
        }

        public override void Start() => _projectEvents.ProjectStarted?.Invoke();

        private void OnEnable() => RegisterEvents();

        private static void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName);

        private void RegisterEvents()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            _menuEvents.StartGameBTN += OnStartGameBTN;
        }

        private void OnSceneLoaded(Scene loadedScene, LoadSceneMode arg1)
        {
            Time.timeScale = 1f;
            if (loadedScene.name == EnvVar.LoginSceneName)
                LoadScene(EnvVar.MainSceneName);
        }

        private void OnStartGameBTN() => LoadScene("Main");
    }
}
