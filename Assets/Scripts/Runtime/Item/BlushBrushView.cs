using UnityEngine;
using UnityEngine.UI;

namespace TestTask_Playnera
{
    public class BlushBrushView : ItemView
    {
        [field: SerializeField] public RectTransform BrushTip { get; private set; }
        [field: SerializeField] public Image BrushTipColor { get; private set; }

        public int CurrentColorIndex { get; private set; }

        public void SetColor(BlushBrushColorView colorView)
        {
            BrushTipColor.sprite = colorView.Color;
            CurrentColorIndex = colorView.Index;
        }
    }
}