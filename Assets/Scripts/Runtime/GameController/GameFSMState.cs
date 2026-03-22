using Templates.FSM;

namespace TestTask_Playnera
{
    public class GameFSMState : FSMState
    {
        protected readonly GameFSM _gameFSM;
        protected readonly GameModel _gameModel;

        public GameFSMState(GameFSM gameFSM, GameModel gameModel)
        {
            _gameFSM = gameFSM;
            _gameModel = gameModel;
        }
    }
}