using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Installers
{
    public class MainSceneInstaller : MonoInstaller<MainSceneInstaller>
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Button _exitBtn;
        public override void InstallBindings()
        {
            Container.BindInstance(_camera);
            Container.BindInstance(_exitBtn);
        }
    }
}