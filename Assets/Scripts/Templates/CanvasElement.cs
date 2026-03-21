using System;

using UnityEngine;
using UnityEngine.EventSystems;

namespace Templates
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasElement : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public Canvas ParentCanvas { get; private set; }
        public RectTransform RectTransform { get; private set; }
        public CanvasGroup CanvasGroup { get; private set; }

        public virtual event Action<CanvasElement, PointerEventData> OnClick;
        public virtual event Action<CanvasElement, PointerEventData> OnEnter;
        public virtual event Action<CanvasElement, PointerEventData> OnExit;

        public virtual void Initialize()
        {
            ParentCanvas = GetComponentInParent<Canvas>();
            RectTransform = GetComponent<RectTransform>();
            CanvasGroup = GetComponent<CanvasGroup>();
        }

        public virtual void Show() => this.gameObject?.SetActive(true);
        public virtual void Hide() => this.gameObject?.SetActive(false);

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke(this, eventData);
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            OnEnter?.Invoke(this, eventData);
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            OnExit?.Invoke(this, eventData);
        }

        public void ClearEvents()
        {
            OnClick = null;
            OnEnter = null;
            OnExit = null;
        }
    }
}