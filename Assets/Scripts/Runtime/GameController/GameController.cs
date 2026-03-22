
using System;

using Templates;

using UnityEngine;
using UnityEngine.EventSystems;

namespace TestTask_Playnera
{
    public class GameController : IDisposable
    {
        private GameFSM _gameFSM;

        private HandPresenter _handPresenter;
        private HandView _handView;

        private CharacterPresenter _characterPresenter;
        private CharacterView _characterView;

        private CreamView _creamView;

        public GameController(GameModel gameModel)
        {
            _gameFSM = new GameFSM(gameModel);
            _gameFSM.InitializeState(new PlayerChooseItemState(_gameFSM, gameModel));
            _gameFSM.InitializeState(new PlayerHandControllState(_gameFSM, gameModel));
            _gameFSM.SwitchStateTo<PlayerChooseItemState>();

            _handPresenter = new HandPresenter();
            _characterPresenter = new CharacterPresenter();
        }

        public void UpdateView(float dt)
        {
            _handView?.ManualUpdate(dt);
            //_characterView?.ManualUpdate(dt);
        }

        public void BindCharacterView(CharacterView characterView)
        {
            _characterView = characterView;
            //_characterView.Initialize(_characterPresenter);
        }

        public void BindHandView(HandView handView)
        {
            _handView = handView;
            //_handView.Initialize(_handPresenter);
        }

        public void BindCreamView(CreamView creamView)
        {
            _creamView = creamView;
            //_creamView.Initialize();

            //_creamView.OnClick += GetCreamEvent;
        }

        private void GetCreamEvent(CanvasElement element, PointerEventData data)
        {
            _handPresenter.GetCream();
            Debug.Log("Click");
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}