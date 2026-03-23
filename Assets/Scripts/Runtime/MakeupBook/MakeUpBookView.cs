using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace TestTask_Playnera
{
    public class MakeUpBookView : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _pages;
        [SerializeField] private Button _previousButton;
        [SerializeField] private Button _nextButton;

        private int currentIndex = 0;

        private void Awake()
        {
            ShowCurrent();
        }

        private void OnEnable()
        {
            _previousButton.onClick.AddListener(ShowPreviousPage);
            _nextButton.onClick.AddListener(ShowNextPage);
        }

        private void OnDisable()
        {
            _previousButton.onClick.RemoveAllListeners();
            _nextButton.onClick.RemoveAllListeners();
        }

        private void ShowCurrent()
        {
            _pages[currentIndex].SetActive(true);
        }

        private void HideCurrent()
        {
            _pages[currentIndex].SetActive(false);
        }

        public void ShowNextPage()
        {
            HideCurrent();
            currentIndex = (currentIndex + 1) % _pages.Count;
            ShowCurrent();
        }

        public void ShowPreviousPage()
        {
            HideCurrent();
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = _pages.Count - 1;
            ShowCurrent();
        }
    }
}