namespace TestTask_Playnera
{
    public class GameController
    {
        private GameFSM _gameFSM;

        public GameController(GameModel gameModel)
        {
            _gameFSM = new GameFSM(gameModel);
            _gameFSM.InitializeState(new PlayerChooseItemState(_gameFSM, gameModel));
            _gameFSM.InitializeState(new PlayerHandControllState(_gameFSM, gameModel));
            _gameFSM.InitializeState(new AnimationState(_gameFSM, gameModel));
            _gameFSM.SwitchStateTo<PlayerChooseItemState>();
        }
    }
}