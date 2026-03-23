using UnityEngine;
using UnityEngine.UI;

namespace TestTask_Playnera
{
    public class LipstickView : ItemView
    {
        [field: SerializeField] public Image Color { get; private set; }

        public LipstickColorView ColorView { get; private set; }

        public void SetColor(LipstickColorView colorView)
        {
            ColorView = colorView;
            Color.sprite = colorView.Color;
        }
    }
}