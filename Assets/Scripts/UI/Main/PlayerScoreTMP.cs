using Components;
using DG.Tweening;
using Events;
using Extensions.DoTween;
using Extensions.Unity.MonoHelper;
using UnityEngine;
using Zenject;

namespace UI.Main
{
    public class PlayerScoreTMP : UITMP, ITweenContainerBind
    {
        [Inject] private GridEvents GridEvents { get; set; }
        private Tween _counterTween;
        public ITweenContainer TweenContainer { get; set; }
        private int _currCounterVal;
        private static int _playerScore;
        
        private void Awake() => TweenContainer = TweenContain.Install(this);

        protected override void RegisterEvents() => GridEvents.MatchGroupDespawn += OnMatchGroupDespawn;

        private void OnMatchGroupDespawn(int arg0)
        {
            Debug.LogWarning($"{arg0}");
            _playerScore += arg0;
            
            if(_counterTween.IsActive()) _counterTween.Kill();
            _counterTween = DOVirtual.Int(_currCounterVal, _playerScore, 0.3f, OnCounterUpdate);
            TweenContainer.AddTween = _counterTween;
            FindObjectOfType<SoundManager>().ScoreSound();
            FindObjectOfType<GameManager>().AddMatchScore(1);

        }

        public void OnCounterUpdate(int val)
        {
            _currCounterVal = val;
            _myTMP.text = $"{_currCounterVal}";
        }

        public static int GetCurrentScore() => _playerScore;
        protected override void UnRegisterEvents() => GridEvents.MatchGroupDespawn -= OnMatchGroupDespawn;
        
    }
}