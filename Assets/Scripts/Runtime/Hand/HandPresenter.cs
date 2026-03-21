namespace TestTask_Playnera
{
    public class HandPresenter
    {
        public string CurrentAnimation { get; private set; }
        public float CurrentAnimationCrossFade { get; private set; }

        public HandPresenter()
        {
            CurrentAnimation = HandAnimationID.IDLE;
            CurrentAnimationCrossFade = 0.2f;
        }

        public void GetCream()
        {
            CurrentAnimation = HandAnimationID.GET_CREAM;
            //CurrentAnimationCrossFade = 1f;
        }

        public void DoCream()
        {
            CurrentAnimation = HandAnimationID.DO_CREAM;
            //CurrentAnimationCrossFade = 0.3f;
        }
    }
}