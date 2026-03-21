namespace TestTask_Playnera
{
    public class CharacterPresenter
    {
        public string CurrentAnimation;

        public CharacterPresenter()
        {
            CurrentAnimation = CharacterAnimationID.IDLE;
        }

        public void RemoveAcne()
        {
            CurrentAnimation = CharacterAnimationID.REMOVE_ACNE;
        }
    }
}