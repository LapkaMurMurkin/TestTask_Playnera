using Templates;

using UnityEngine;
using UnityEngine.UI;

namespace TestTask_Playnera
{
    public class LipstickColorView : CanvasElement
    {
        public Sprite Color { get; private set; }
        public int Index { get; set; } = -1;

        protected override void Awake()
        {
            base.Awake();
            Image thisImage = this.GetComponent<Image>();
            Color = thisImage.sprite;
        }
    }
}