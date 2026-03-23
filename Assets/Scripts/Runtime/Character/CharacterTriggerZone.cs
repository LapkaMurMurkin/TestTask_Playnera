using Templates;
using UnityEngine;

namespace TestTask_Playnera 
{
    public abstract class CharacterTriggerZone : CanvasElement
    {
        public abstract bool ApplyItem(ItemView itemView);
    }
}