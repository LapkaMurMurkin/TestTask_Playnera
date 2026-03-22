using UnityEngine;

namespace TestTask_Playnera
{
    public class PlayerHandControllState : GameFSMState
    {
        public PlayerHandControllState(GameFSM gameFSM, GameModel gameModel) : base(gameFSM, gameModel)
        {
        }

        public override void Enter()
        {
            _gameModel.HandView.EnablePlayerControll();

            _gameModel.HandView.OnItemDrop += DoItemInteraction;
            _gameModel.HandView.OnReturnItem += ReturnCreamEndHandler;
        }

        public override void Exit()
        {
            _gameModel.HandView.DisablePlayerControll();

            _gameModel.HandView.OnItemDrop -= DoItemInteraction;
            _gameModel.HandView.OnReturnItem -= ReturnCreamEndHandler;
        }

        private void DoItemInteraction(ItemView itemView, GameObject overObject)
        {
            if (overObject is null)
                return;

            if (overObject.TryGetComponent<CharacterTriggerZone>(out CharacterTriggerZone triggerZone))
            {
                triggerZone.ApplyItem(itemView);
                _gameModel.HandView.DisablePlayerControll();
                _gameModel.HandView.DOCurrentItemAnimation();
            }
        }

        private void ReturnCreamEndHandler()
        {
            _gameFSM.SwitchStateTo<PlayerChooseItemState>();
        }
    }
}