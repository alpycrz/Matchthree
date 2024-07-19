using Components;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = nameof(ProjectSettings),menuName = EnvVar.ProjectSettingsPath, order = 0)]
    public class ProjectSettings : ScriptableObject
    {
        [SerializeField] private GridManager.Settings _gridManagerSettings;
        [SerializeField] private GameManager.Settings _gameManagerSettings;
        
        public GridManager.Settings GridManagerSettings => _gridManagerSettings;

        public GameManager.Settings GameManagerSettings => _gameManagerSettings;

    }
}