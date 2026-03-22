using Templates;

using UnityEngine.EventSystems;

namespace TestTask_Playnera
{
    public class PlayerChooseItemState : GameFSMState
    {
        public PlayerChooseItemState(GameFSM gameFSM, GameModel gameModel) : base(gameFSM, gameModel)
        {
        }

        public override void Enter()
        {
            _gameModel.CreamView.OnClick += GetItem;
            _gameModel.BlushBrushView.OnClick += GetItem;

            _gameModel.HandView.OnGetItem += SwitchToHandControll;
        }

        public override void Exit()
        {
            _gameModel.CreamView.OnClick -= GetItem;
            _gameModel.BlushBrushView.OnClick -= GetItem;

            _gameModel.HandView.OnGetItem -= SwitchToHandControll;
        }

        private void GetItem(CanvasElement element, PointerEventData data)
        {
            _gameModel.HandView.GetItemAnimation(element);
        }

        private void SwitchToHandControll()
        {
            _gameFSM.SwitchStateTo<PlayerHandControllState>();
        }
    }
}