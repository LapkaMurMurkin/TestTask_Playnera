using Templates.FSM;

namespace TestTask_Playnera
{
    public class GameFSM : FSM
    {
        private readonly GameModel _gameModel;

        public GameFSM(GameModel gameModel)
        {
            _gameModel = gameModel;
        }
    }
}