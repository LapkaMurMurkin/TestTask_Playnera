using System;

namespace TestTask_Playnera
{
    public class FaceTriggetZone : CharacterTriggerZone
    {
        public event Action OnCreamItem;
        public event Action<int> OnBlushBrushItem;
        public event Action<int> OnLipstickItem;

        public override bool ApplyItem(ItemView itemView)
        {
            if (itemView is CreamView creamView)
            {
                OnCreamItem?.Invoke();
                return true;
            }
            else if (itemView is BlushBrushView blushBrushView)
            {
                OnBlushBrushItem?.Invoke(blushBrushView.CurrentColorIndex);
                return true;
            }
            else if (itemView is LipstickView lipstickView)
            {
                OnLipstickItem?.Invoke(lipstickView.ColorView.Index);
                return true;
            }

            return false;
        }
    }
}