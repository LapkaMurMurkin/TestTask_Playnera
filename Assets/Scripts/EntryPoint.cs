using UnityEngine;

namespace TestTask_Playnera
{
    public class EntryPoint : MonoBehaviour
    {
        private GameController _gameController;

        [SerializeField] private HandView _handView;
        [SerializeField] private CreamView _creamView;
        [SerializeField] private CharacterView _characterView;


        private void Awake()
        {
            _gameController = new GameController();
            _gameController.BindHandView(_handView);
            _gameController.BindCreamView(_creamView);
            _gameController.BindCharacterView(_characterView);
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