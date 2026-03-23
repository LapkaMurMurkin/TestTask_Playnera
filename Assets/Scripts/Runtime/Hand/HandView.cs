using System;

using DG.Tweening;

using Templates;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TestTask_Playnera
{
    public class HandView : CanvasElement, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private HandAnimator _handAnimator;

        [SerializeField] private Animator _animator;
        [field: SerializeField] public HandAnimationEvents AnimationEvents { get; private set; }

        [SerializeField] private Image _handImage;
        [SerializeField] private CreamView _creamView;
        [SerializeField] private BlushBrushView _blushBrushView;
        [SerializeField] private LipstickView _lipstickView;

        public ItemView CurrentItem { get; private set; }

        public event Action<ItemView, GameObject> OnHandDrop;

        protected override void Awake()
        {
            base.Awake();
            _handAnimator = new HandAnimator(_animator);
        }

        public void EnableControll()
        {
            _animator.enabled = false;
            this.CanvasGroup.interactable = true;
        }

        public void DisableControll()
        {
            _animator.enabled = true;
            this.CanvasGroup.interactable = false;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            this.CanvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            this.RectTransform.anchoredPosition += eventData.delta / this.ParentCanvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            this.CanvasGroup.blocksRaycasts = true;
            OnHandDrop?.Invoke(CurrentItem, eventData.pointerEnter);
        }

        public void GetCream()
        {
            CurrentItem = _creamView;
            _handAnimator.SwitchAnimationTo(HandAnimationID.GET_CREAM, 0f);
        }

        public void GetBlushBrush()
        {
            CurrentItem = _blushBrushView;
            _handAnimator.SwitchAnimationTo(HandAnimationID.GET_BLUSH_BRUSH, 0f);
        }

        public void GetBlushBrushColor(BlushBrushColorView colorView)
        {
            _animator.enabled = false;

            Vector3 startPosition = this.transform.position;
            Vector3 offset = _blushBrushView.BrushTip.position - this.transform.position;
            Vector3 finalPosition = colorView.transform.position - offset;

            Sequence sequence = DOTween.Sequence();
            sequence.Append(this.transform.DOMove(finalPosition, 0.5f).SetEase(Ease.OutQuad));
            sequence.AppendCallback(() => _blushBrushView.SetColor(colorView));
            sequence.Append(transform.DOShakePosition(0.7f, 20, 5).SetEase(Ease.InBounce));
            sequence.Join(_blushBrushView.BrushTipColor.DOFade(0.75f, 0.5f));
            sequence.Append(this.transform.DOMove(startPosition, 0.5f).SetEase(Ease.OutQuad));
            sequence.OnComplete(() =>
            {
                _animator.enabled = true;
                AnimationEvents.InvokeOnGetBlushBrushColorEnd();
            });
        }

        public void GetLipstick(LipstickColorView colorView)
        {
            CurrentItem = _lipstickView;
            _animator.enabled = false;

            Vector3 startPosition = this.transform.position;
            Vector3 offset = _lipstickView.transform.position - this.transform.position;
            Vector3 finalPosition = colorView.transform.position - offset;

            Sequence sequence = DOTween.Sequence();
            sequence.Append(this.transform.DOMove(finalPosition, 1f).SetEase(Ease.OutQuad));
            sequence.Join(this.CanvasGroup.DOFade(1, 0.5f));
            sequence.AppendCallback(() =>
            {
                _lipstickView.SetColor(colorView);
                _lipstickView.gameObject.SetActive(true);
                AnimationEvents.InvokeOnGetLipstick();
            });
            sequence.Append(this.transform.DOMove(startPosition, 1f).SetEase(Ease.OutQuad));
            sequence.OnComplete(() =>
            {
                _animator.enabled = true;
                _handAnimator.SwitchAnimationTo(HandAnimationID.SHOW, 0f);
                AnimationEvents.InvokeOnGetLipstickEnd();
            });
        }

        public void ReturnLipstick()
        {
            _animator.enabled = false;

            Vector3 startPosition = this.transform.position;
            Vector3 offset = _lipstickView.transform.position - this.transform.position;
            Vector3 finalPosition = _lipstickView.ColorView.transform.position - offset;

            Sequence sequence = DOTween.Sequence();
            sequence.Append(this.transform.DOMove(finalPosition, 1f).SetEase(Ease.OutQuad));
            sequence.AppendCallback(() =>
            {
                _lipstickView.gameObject.SetActive(false);
                AnimationEvents.InvokeOnReturnLipstick();
            });
            sequence.Append(this.RectTransform.DOAnchorPos(Vector3.zero, 1f).SetEase(Ease.OutQuad));
            sequence.Join(this.CanvasGroup.DOFade(0, 0.7f));
            sequence.OnComplete(() =>
            {
                _animator.enabled = true;
                _handAnimator.SwitchAnimationTo(HandAnimationID.HIDE, 0f);
                AnimationEvents.InvokeOnReturnLipstickEnd();
            });
        }

        public void DOCurrentItemAnimation()
        {
            if (CurrentItem is CreamView)
                _handAnimator.SwitchAnimationTo(HandAnimationID.DO_CREAM, 0f);
            else if (CurrentItem is BlushBrushView)
                _handAnimator.SwitchAnimationTo(HandAnimationID.DO_BLUSH_BRUSH, 0f);
            else if (CurrentItem is LipstickView)
                _handAnimator.SwitchAnimationTo(HandAnimationID.DO_LIPSTICK, 0f);
        }
    }
}