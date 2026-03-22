using UnityEngine;

namespace TestTask_Playnera
{
    public class EntryPoint : MonoBehaviour
    {
        private GameModel _gameModel;
        private GameController _gameController;

        [SerializeField] private HandView _handView;
        [SerializeField] private CreamView _creamView;
        [SerializeField] private BlushBrushView _blushBrushView;
        [SerializeField] private CharacterView _characterView;

        private void Awake()
        {
            _gameModel = new GameModel();
            _gameModel.HandView = _handView;
            _gameModel.CreamView = _creamView;
            _gameModel.BlushBrushView = _blushBrushView;
            _gameModel.CharacterView = _characterView;

            _gameController = new GameController(_gameModel);
        }

        private void Update()
        {
            _gameController.UpdateView(Time.deltaTime);
        }

        private void OnDestroy()
        {
            _gameController.Dispose();
        }
    }
}