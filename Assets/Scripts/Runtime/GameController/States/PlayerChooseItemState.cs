using Templates;

using UnityEngine;

namespace TestTask_Playnera
{
    public class PlayerChooseItemState : GameFSMState
    {
        public PlayerChooseItemState(GameFSM gameFSM, GameModel gameModel) : base(gameFSM, gameModel) { }

        public override void Enter()
        {
            _gameModel.InteractionBlockLayer.SetActive(false);
            _gameModel.HandView.DisableControll();

            _gameModel.LoofahButton.onClick.AddListener(_gameModel.CharacterView.ClearFace);
            _gameModel.CreamButton.onClick.AddListener(GetCream);
            _gameModel.BlushBrushPalette.OnColorClick += GetBlushBrushColor;
            _gameModel.LipstickPaletteView.OnColorClick += GetLipstick;
        }

        public override void Exit()
        {
            _gameModel.LoofahButton.onClick.RemoveAllListeners();
            _gameModel.CreamButton.onClick.RemoveAllListeners();
            _gameModel.BlushBrushPalette.OnColorClick -= GetBlushBrushColor;
            _gameModel.LipstickPaletteView.OnColorClick -= GetLipstick;
        }

        private void GetCream()
        {
            _gameModel.HandView.GetCream();

            void HideGetCreamButton()
            {
                _gameModel.HandView.AnimationEvents.OnGetCream -= HideGetCreamButton;
                _gameModel.CreamButton.gameObject.SetActive(false);
            }
            void ShowGetCreamButton()
            {
                _gameModel.HandView.AnimationEvents.OnReturnCream -= ShowGetCreamButton;
                _gameModel.CreamButton.gameObject.SetActive(true);
            }

            _gameModel.HandView.AnimationEvents.OnGetCream += HideGetCreamButton;
            _gameModel.HandView.AnimationEvents.OnReturnCream += ShowGetCreamButton;

            SwitchToAnimationState();
        }

        private void GetBlushBrushColor(CanvasElement element, Sprite color)
        {
            _gameModel.HandView.GetBlushBrush();

            void HideBlushBrushImage()
            {
                _gameModel.HandView.AnimationEvents.OnGetBlushBrush -= HideBlushBrushImage;
                _gameModel.BlushBrushImage.gameObject.SetActive(false);
            }
            void ShowBlushBrushImage()
            {
                _gameModel.HandView.AnimationEvents.OnReturnBlushBrush -= ShowBlushBrushImage;
                _gameModel.BlushBrushImage.gameObject.SetActive(true);
            }

            void GetColorAnimation()
            {
                _gameModel.HandView.AnimationEvents.OnGetBlushBrushEnd -= GetColorAnimation;
                _gameModel.HandView.GetBlushBrushColor(element as BlushBrushColorView);
            }

            _gameModel.HandView.AnimationEvents.OnGetBlushBrush += HideBlushBrushImage;
            _gameModel.HandView.AnimationEvents.OnGetBlushBrushEnd += GetColorAnimation;
            _gameModel.HandView.AnimationEvents.OnReturnBlushBrush += ShowBlushBrushImage;

            SwitchToAnimationState();
        }

        private void GetLipstick(CanvasElement element, Sprite sprite)
        {
            _gameModel.HandView.GetLipstick(element as LipstickColorView);

            void HideLipstickImage()
            {
                _gameModel.HandView.AnimationEvents.OnGetLipstick -= HideLipstickImage;
                element.Hide();
            }
            void ShowLipstickImage()
            {
                _gameModel.HandView.AnimationEvents.OnReturnLipstick -= ShowLipstickImage;
                element.Show();
            }

            void ReturnLipstickAnimation()
            {
                _gameModel.HandView.AnimationEvents.OnDOLipstickEnd -= ReturnLipstickAnimation;
                _gameModel.HandView.ReturnLipstick();
            }

            _gameModel.HandView.AnimationEvents.OnGetLipstick += HideLipstickImage;
            _gameModel.HandView.AnimationEvents.OnDOLipstickEnd += ReturnLipstickAnimation;
            _gameModel.HandView.AnimationEvents.OnReturnLipstick += ShowLipstickImage;

            SwitchToAnimationState();
        }

        private void SwitchToAnimationState()
        {
            _gameFSM.SwitchStateTo<AnimationState>();
        }
    }
}