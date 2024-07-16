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
        private ProjectEvents _projectEvents;
        private InputEvents _inputEvents;
        private GridEvents _gridEvents;
        private ProjectSettings _projectSettings;
        
        private MenuEvents _menuEvents;
        private MainUIEvents _mainUIEvents;
        private static PlayerData _playerData;
        public static PlayerData PlayerData => _playerData;

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

        private void Awake() => RegisterEvents();

        private void InstallData() => _playerData = new PlayerData();

        public override void Start() => _projectEvents.ProjectStarted?.Invoke();

        private static void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName);

        private void RegisterEvents()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            MenuEvents.StartGameBTN += OnStartGameBTN;
            MainUIEvents.ExitBTN += OnExitBTN;
        }

        private void OnSceneLoaded(Scene loadedScene, LoadSceneMode arg1)
        {
            if(loadedScene.name == EnvVar.LoginSceneName)
            {
                LoadScene(EnvVar.MainSceneName);
            }
        }
        private void OnStartGameBTN() => LoadScene("Main");

        private void OnExitBTN() => LoadScene("Menu");
    }
}
