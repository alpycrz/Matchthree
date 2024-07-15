using DG.Tweening;
using Events;
using UI.Utils;
using UnityEngine;

namespace UI.Menu
{
    public class ScoreboardBTN : UIBTN
    {
        [SerializeField] private Transform _transform;
        private Sequence _clickSizeSeq;

        protected override void OnDisable()
        {
            base.OnDisable();
            if (_clickSizeSeq.IsActive()) _clickSizeSeq.Kill();
        }

        protected override void OnClick()
        {
            _transform.localScale = Vector3.one;
            _clickSizeSeq = DOTween.Sequence();

            Tween sizeIncTwn = _transform.DOScale(Vector3.one * 1.85f, 0.2f);
            sizeIncTwn.SetEase(Ease.OutElastic);

            Tween sizeDcrTwn = _transform.DOScale(Vector3.one * 1.8f, 0.2f);
            sizeDcrTwn.SetEase(Ease.OutElastic);

            _clickSizeSeq.Append(sizeIncTwn);
            _clickSizeSeq.Append(sizeDcrTwn);

            Tween secCounterTween = DOVirtual.Float
            (
                0, 1f, 0.03f,
                delegate(float e) { Debug.LogWarning($"{e} = e"); }
            );

            _clickSizeSeq.Append(secCounterTween);

            _clickSizeSeq.onComplete += delegate { MenuEvents.ScoreboardBTN?.Invoke(); };
        }
    }
}