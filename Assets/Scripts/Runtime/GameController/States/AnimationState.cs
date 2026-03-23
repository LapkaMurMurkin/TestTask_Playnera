namespace TestTask_Playnera
{
    public class AnimationState : GameFSMState
    {
        public AnimationState(GameFSM gameFSM, GameModel gameModel) : base(gameFSM, gameModel) { }

        public override void Enter()
        {
            _gameModel.InteractionBlockLayer.SetActive(true);

            _gameModel.HandView.AnimationEvents.OnReturnCreamEnd += SwitchToChooseItem;
            _gameModel.HandView.AnimationEvents.OnReturnBlushBrushEnd += SwitchToChooseItem;
            _gameModel.HandView.AnimationEvents.OnReturnLipstickEnd += SwitchToChooseItem;

            _gameModel.HandView.AnimationEvents.OnGetCreamEnd += SwitchToHandControll;
            _gameModel.HandView.AnimationEvents.OnGetBlushBrushColorEnd += SwitchToHandControll;
            _gameModel.HandView.AnimationEvents.OnGetLipstickEnd += SwitchToHandControll;
        }

        public override void Exit()
        {
            _gameModel.InteractionBlockLayer.SetActive(false);

            _gameModel.HandView.AnimationEvents.OnReturnCreamEnd -= SwitchToChooseItem;
            _gameModel.HandView.AnimationEvents.OnReturnBlushBrushEnd -= SwitchToChooseItem;
            _gameModel.HandView.AnimationEvents.OnReturnLipstickEnd -= SwitchToChooseItem;

            _gameModel.HandView.AnimationEvents.OnGetCreamEnd -= SwitchToHandControll;
            _gameModel.HandView.AnimationEvents.OnGetBlushBrushColorEnd -= SwitchToHandControll;
            _gameModel.HandView.AnimationEvents.OnGetLipstickEnd -= SwitchToHandControll;
        }

        private void SwitchToHandControll()
        {
            _gameFSM.SwitchStateTo<PlayerHandControllState>();
        }

        private void SwitchToChooseItem()
        {
            _gameFSM.SwitchStateTo<PlayerChooseItemState>();
        }
    }
}