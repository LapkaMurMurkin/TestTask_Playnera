using System.Collections.Generic;

using DG.Tweening;

using UnityEngine;
using UnityEngine.UI;

namespace TestTask_Playnera
{
    public class CharacterView : MonoBehaviour
    {
        private CharacterAnimator _characterAnimator;

        [SerializeField] private Image _acne;
        [SerializeField] private List<Image> _blushColors;
        [SerializeField] private List<Image> _lipstickColors;
        [SerializeField] private FaceTriggetZone _faceTriggerZone;
        [SerializeField] private Animator _animator;

        private int _currentBlushColorIndex;
        private int _currentLipstickColorIndex;

        public void Awake()
        {
            _characterAnimator = new CharacterAnimator(_animator);
            _currentBlushColorIndex = -1;
            _currentLipstickColorIndex = -1;
        }

        private void OnEnable()
        {
            _faceTriggerZone.OnCreamItem += RemoveAcne;
            _faceTriggerZone.OnBlushBrushItem += SetBlush;
            _faceTriggerZone.OnLipstickItem += SetLipstick;

        }

        private void OnDisable()
        {
            _faceTriggerZone.OnCreamItem -= RemoveAcne;
            _faceTriggerZone.OnBlushBrushItem -= SetBlush;
            _faceTriggerZone.OnLipstickItem -= SetLipstick;
        }

        public void RemoveAcne()
        {
            _acne.DOFade(0f, 0.5f);
        }

        public void SetBlush(int colorIndex)
        {
            if (colorIndex < 0 || colorIndex > _blushColors.Count - 1)
                return;

            Sequence sequence = DOTween.Sequence();
            if (_currentBlushColorIndex is not -1)
                sequence.Append(_blushColors[_currentBlushColorIndex].DOFade(0f, 0.5f));

            _currentBlushColorIndex = colorIndex;
            sequence.Join(_blushColors[_currentBlushColorIndex].DOFade(1f, 0.5f));
        }

        private void SetLipstick(int colorIndex)
        {
            if (colorIndex < 0 || colorIndex > _lipstickColors.Count - 1)
                return;

            Sequence sequence = DOTween.Sequence();
            if (_currentLipstickColorIndex is not -1)
                sequence.Append(_lipstickColors[_currentLipstickColorIndex].DOFade(0f, 0.5f));

            _currentLipstickColorIndex = colorIndex;
            sequence.Join(_lipstickColors[_currentLipstickColorIndex].DOFade(1f, 0.5f));
        }

        public void ClearFace()
        {
            Color clearColor = _acne.color;
            clearColor.a = 1f;
            _acne.color = clearColor;

            if (_currentBlushColorIndex >= 0 && _currentBlushColorIndex < _blushColors.Count - 1)
            {
                clearColor = _blushColors[_currentBlushColorIndex].color;
                clearColor.a = 0f;
                _blushColors[_currentBlushColorIndex].color = clearColor;
            }

            if (_currentLipstickColorIndex >= 0 && _currentLipstickColorIndex < _lipstickColors.Count - 1)
            {
                clearColor = _lipstickColors[_currentLipstickColorIndex].color;
                clearColor.a = 0f;
                _lipstickColors[_currentLipstickColorIndex].color = clearColor;
            }
        }
    }
}