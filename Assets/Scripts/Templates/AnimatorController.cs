using UnityEngine;

namespace Templates
{
    public class AnimatorController
    {
        public Animator Animator { get; private set; }
        public string CurrentAnimation { get; private set; }

        public AnimatorController(Animator animator)
        {
            Animator = animator;
        }

        public void SwitchAnimationTo(string animationName, float crossFade = 0.2f)
        {
            if (CurrentAnimation != animationName)
            {
                CurrentAnimation = animationName;
                Animator.CrossFade(animationName, crossFade);
            }
        }

        public void StopPlayback() => Animator.speed = 0;
        public void ResumePlayback() => Animator.speed = 1;
    }
}
