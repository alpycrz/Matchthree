using System;
using Events;
using UnityEngine;
using Zenject;

namespace Components
{
    public class TestCube : MonoBehaviour
    {
        [Inject] private ProjectEvents ProjectsEvents { get; set; }

        private void OnEnable()
        {
            RegisterEvents();
        }

        private void OnDisable()
        {
            UnRegisterEvents();
        }

        private void RegisterEvents()
        {
            ProjectsEvents.ProjectStarted += OnProjectInstalled;
        }

        private void OnProjectInstalled()
        {
            Debug.LogWarning("var");
        }

        private void UnRegisterEvents()
        {
            ProjectsEvents.ProjectStarted -= OnProjectInstalled;
        }
    }
}