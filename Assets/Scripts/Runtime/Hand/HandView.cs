using System;

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
        [SerializeField] private CreamView _creamView;
        [SerializeField] private BlushBrushView _blushBrushView;


        public ItemView CurrentItem { get; private set; }

        public event Action OnGetItem;
        private void InvokeOnGetItem() => OnGetItem?.Invoke();
        public event Action OnReturnItem;
        private void InvokeOnReturnItem() => OnReturnItem?.Invoke();

        public event Action<ItemView, GameObject> OnItemDrop;
        //private void InvokeOnItemDrop() => OnItemDrop?.Invoke();

        private void Awake()
        {
            base.Initialize();
            _handAnimator = new HandAnimator(_animator);
        }

        public void ManualUpdate(float dt)
        {
            if (_presenter.CurrentAnimation != _handAnimator.CurrentAnimation)
                EnableAnimation(_presenter.CurrentAnimation, _presenter.CurrentAnimationCrossFade);
        }

        private void EnableAnimation(string animName, float crossFade)
        {
            _handAnimator.SwitchAnimationTo(animName, crossFade);
        }

        public void EnablePlayerControll()
        {
            _animator.enabled = false;
            this.CanvasGroup.interactable = true;
        }

        public void DisablePlayerControll()
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
            OnItemDrop?.Invoke(CurrentItem, eventData.pointerEnter);

            /*             if (eventData.pointerEnter != null)
                            if (eventData.pointerEnter.TryGetComponent<FaceView>(out FaceView faceView))
                            {
                                _presenter.DoCream();
                                faceView.RemoveAcne();
                            } */
        }

/*         public void GetCream()
        {
            CurrentItem = _creamView;
            _handAnimator.SwitchAnimationTo(HandAnimationID.GET_CREAM);
        }

        public void GetBlushBrush()
        {
            CurrentItem = _blushBrushView;
            _handAnimator.SwitchAnimationTo(HandAnimationID.GET_BLUSH_BRUSH);
        } */

        public void GetItemAnimation(CanvasElement canvasElement)
        {
            if (canvasElement is CreamView)
            {
                CurrentItem = _creamView;
                _handAnimator.SwitchAnimationTo(HandAnimationID.GET_CREAM, 0f);
            }
            else if (canvasElement is BlushBrushView)
            {
                CurrentItem = _blushBrushView;
                _handAnimator.SwitchAnimationTo(HandAnimationID.GET_BLUSH_BRUSH, 0f);
            }

        }

        public void DOCurrentItemAnimation()
        {
            if (CurrentItem is CreamView)
                _handAnimator.SwitchAnimationTo(HandAnimationID.DO_CREAM, 0f);
            else if (CurrentItem is BlushBrushView)
                _handAnimator.SwitchAnimationTo(HandAnimationID.DO_BLUSH_BRUSH, 0f);
        }
    }
}