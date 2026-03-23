using UnityEngine;
using UnityEngine.UI;

namespace TestTask_Playnera
{
    public class EntryPoint : MonoBehaviour
    {
        private GameModel _gameModel;
        private GameController _gameController;

        [SerializeField] private GameObject _interactionBlockLayer;
        [SerializeField] private Button _creamButton;
        [SerializeField] private Button _loofahButton;
        [SerializeField] private Image _blushBrushImage;
        [SerializeField] private HandView _handView;
        [SerializeField] private CreamView _creamView;
        [SerializeField] private BlushBrushView _blushBrushView;
        [SerializeField] private BlushBrushPaletteView _blushBrushPalette;
        [SerializeField] private LipstickPaletteView _lipstickPaletteView;
        [SerializeField] private CharacterView _characterView;

        private void Start()
        {
            _gameModel = new GameModel();
            _gameModel.InteractionBlockLayer = _interactionBlockLayer;
            _gameModel.BlushBrushImage = _blushBrushImage;
            _gameModel.CreamButton = _creamButton;
            _gameModel.LoofahButton = _loofahButton;
            _gameModel.HandView = _handView;
            _gameModel.CreamView = _creamView;
            _gameModel.BlushBrushView = _blushBrushView;
            _gameModel.BlushBrushPalette = _blushBrushPalette;
            _gameModel.LipstickPaletteView = _lipstickPaletteView;
            _gameModel.CharacterView = _characterView;

            _gameController = new GameController(_gameModel);
        }
    }
}