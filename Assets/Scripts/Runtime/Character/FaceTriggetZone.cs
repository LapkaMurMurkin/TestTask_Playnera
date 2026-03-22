using System;

namespace TestTask_Playnera
{
    public class FaceTriggetZone : CharacterTriggerZone
    {
        private CharacterView _characterView;

        public event Action OnCreamItem;

        public override bool ApplyItem(ItemView itemView)
        {
            if (itemView is CreamView creamView)
            {
                OnCreamItem?.Invoke();
                return true;
            }

            return false;
        }
    }
}