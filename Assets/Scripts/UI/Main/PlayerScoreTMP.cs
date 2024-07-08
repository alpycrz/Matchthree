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
        private int _playerScore;
        [SerializeField] private int scoreMultiplier = 10;

        private void Awake() => TweenContainer = TweenContain.Install(this);

        protected override void RegisterEvents() => GridEvents.MatchGroupDespawn += OnMatchGroupDespawn;

        private void OnMatchGroupDespawn(int arg0)
        {
            Debug.LogWarning($"{arg0}");
            _playerScore += arg0 * scoreMultiplier;
            
            if(_counterTween.IsActive()) _counterTween.Kill();
            _counterTween = DOVirtual.Int(_currCounterVal, _playerScore, 0.3f, OnCounterUpdate);
            TweenContainer.AddTween = _counterTween;
            FindObjectOfType<SoundManager>().ScoreSound();

        }

        private void OnCounterUpdate(int val)
        {
            _currCounterVal = val;
            _myTMP.text = $"{_currCounterVal}";
        }
        protected override void UnRegisterEvents() => GridEvents.MatchGroupDespawn -= OnMatchGroupDespawn;

    }
}