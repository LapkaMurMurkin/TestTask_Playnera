using System;
using System.Collections.Generic;

using Templates;

using UnityEngine;
using UnityEngine.EventSystems;

namespace TestTask_Playnera
{
    public class LipstickPaletteView : CanvasElement
    {
        [SerializeField] private List<LipstickColorView> _colors;

        public event Action<CanvasElement, Sprite> OnColorClick;

        protected override void Awake()
        {
            base.Awake();
            Subscribe();
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            for (int i = 0; i < _colors.Count; i++)
            {
                LipstickColorView color = _colors[i];
                color.Index = i;
                color.OnClick += InvokeOnClick;
            }
        }

        private void Unsubscribe()
        {
            foreach (LipstickColorView color in _colors)
                color.OnClick -= InvokeOnClick;
        }

        private void InvokeOnClick(CanvasElement element, PointerEventData data)
        {
            if (element is LipstickColorView colorView)
                OnColorClick?.Invoke(element, colorView.Color);
        }
    }
}