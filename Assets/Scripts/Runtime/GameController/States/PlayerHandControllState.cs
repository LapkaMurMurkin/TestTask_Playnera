using UnityEngine;

namespace TestTask_Playnera
{
    public class PlayerHandControllState : GameFSMState
    {
        public PlayerHandControllState(GameFSM gameFSM, GameModel gameModel) : base(gameFSM, gameModel) { }

        public override void Enter()
        {
            _gameModel.InteractionBlockLayer.SetActive(false);
            _gameModel.HandView.EnableControll();

            _gameModel.HandView.OnHandDrop += DoItemInteraction;
        }

        public override void Exit()
        {
            _gameModel.InteractionBlockLayer.SetActive(true);
            _gameModel.HandView.DisableControll();

            _gameModel.HandView.OnHandDrop -= DoItemInteraction;
        }

        private void DoItemInteraction(ItemView itemView, GameObject overObject)
        {
            if (overObject is null)
                return;

            if (overObject.TryGetComponent<CharacterTriggerZone>(out CharacterTriggerZone triggerZone))
            {
                if (triggerZone.ApplyItem(itemView))
                {
                    _gameModel.HandView.DOCurrentItemAnimation();
                    _gameFSM.SwitchStateTo<AnimationState>();
                }
            }
        }
    }
}