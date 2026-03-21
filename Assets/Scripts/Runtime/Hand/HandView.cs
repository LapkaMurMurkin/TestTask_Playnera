using Templates;

using UnityEngine;
using UnityEngine.EventSystems;

namespace TestTask_Playnera
{
    public class HandView : CanvasElement, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private HandPresenter _presenter;
        private HandAnimator _handAnimator;

        [SerializeField] private Animator _animator;

        public string ItemID;

        public void Initialize(HandPresenter handPresenter)
        {
            base.Initialize();
            _presenter = handPresenter;
            _handAnimator = new HandAnimator(_animator);
        }

        public void ManualUpdate(float dt)
        {
            if (_presenter.CurrentAnimation != _handAnimator.CurrentAnimation)
                EnableAnimation(_presenter.CurrentAnimation, _presenter.CurrentAnimationCrossFade);
        }

        private void EnableAnimation(string animName, float crossFade)
        {
            BlockControllAnimationEvent();
            _handAnimator.SwitchAnimationTo(animName, crossFade);
        }

        private void PlayerControllAnimationEvent()
        {
            _animator.enabled = false;
            this.CanvasGroup.interactable = true;
        }

        private void BlockControllAnimationEvent()
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

            if (eventData.pointerEnter != null)
                if (eventData.pointerEnter.TryGetComponent<FaceView>(out FaceView faceView))
                {
                    _presenter.DoCream();
                    faceView.RemoveAcne();
                }
        }
    }
}