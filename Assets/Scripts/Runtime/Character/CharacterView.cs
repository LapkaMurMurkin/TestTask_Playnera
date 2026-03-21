using Templates;

using UnityEngine;

namespace TestTask_Playnera
{
    public class CharacterView : CanvasElement
    {
        private CharacterPresenter _presenter;
        private CharacterAnimator _characterAnimator;

        [SerializeField] private FaceView _faceView;
        [SerializeField] private Animator _animator;

        public string ItemID;

        public void Initialize(CharacterPresenter presenter)
        {
            base.Initialize();
            _presenter = presenter;
            _characterAnimator = new CharacterAnimator(_animator);

            _faceView.Initialize(_presenter);
        }

        public void ManualUpdate(float dt)
        {
            _characterAnimator.SwitchAnimationTo(_presenter.CurrentAnimation);
        }
    }
}