using UnityEngine;

namespace TestTask_Playnera
{
    public class CharacterView : MonoBehaviour
    {
        private CharacterPresenter _presenter;
        private CharacterAnimator _characterAnimator;

        [SerializeField] private FaceTriggetZone _faceTriggerZone;
        [SerializeField] private Animator _animator;

        public string ItemID;

        public void Awake()
        {
            _characterAnimator = new CharacterAnimator(_animator);
        }

        private void OnEnable()
        {
            _faceTriggerZone.OnCreamItem += RemoveAcne;
        }

        private void OnDisable()
        {
            _faceTriggerZone.OnCreamItem += RemoveAcne;
        }

        public void RemoveAcne()
        {
            _characterAnimator.SwitchAnimationTo(CharacterAnimationID.REMOVE_ACNE);
        }
    }
}