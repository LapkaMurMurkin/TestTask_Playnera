using Templates;

namespace TestTask_Playnera
{
    public class FaceView : CanvasElement
    {
        private CharacterPresenter _presenter;

        public void Initialize(CharacterPresenter presenter)
        {
            base.Initialize();
            _presenter = presenter;
        }

        public void RemoveAcne()
        {
            _presenter.RemoveAcne();
        }
    }
}