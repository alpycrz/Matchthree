using DG.Tweening;
using Events;
using UI.Utils;
using UnityEngine;
using Zenject;

namespace UI.Menu
{
    public class StartGameBTN : UIBTN
    {
        [Inject] private MenuEvents MenuEvents { get; set; }

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

            Tween sizeIncTwn = _transform.DOScale(Vector3.one * 2.3f, 0.2f);
            sizeIncTwn.SetEase(Ease.OutElastic);

            Tween sizeDcrTwn = _transform.DOScale(Vector3.one * 2.25f, 0.2f);
            sizeDcrTwn.SetEase(Ease.OutElastic);

            _clickSizeSeq.Append(sizeIncTwn);
            _clickSizeSeq.Append(sizeDcrTwn);

             Tween secCounterTween = DOVirtual.Float
             (
                 0, 1f, 0.03f, 
                 delegate(float e)
                 
                 { Debug.LogWarning($"{e} = e"); }
             );

             _clickSizeSeq.Append(secCounterTween);

            _clickSizeSeq.onComplete += delegate() { MenuEvents.StartGameBTN?.Invoke();};
        }

    }
}