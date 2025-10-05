using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ResultWindow : MonoBehaviour
    {
        [SerializeField] private GameObject _window;
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private EnemyMoves _king;
        [SerializeField] private List<Image> _kingResultSlots;
        [SerializeField] private Sprite _emptySprite;
        [SerializeField] private PriestMoves _priest;
        [SerializeField] private List<Image>  _priestResultSlots;
        public (int, int) Score = (0, 0);
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private GameObject _kingWinText;
        [SerializeField] private GameObject _priestWinText;
        [SerializeField] private GameObject _kingLoseText;
        [SerializeField] private GameObject _priestLoseText;

        public void Show()
        {
            _window.SetActive(true);
            //_title.text = $"{season} IS OVER";
            FillKingResults();
            FillPriestResults();

            var kingsResult = _king.GetFilledResourses().Count;
            var priestResult = _priest.GetFilledResourses().Count;

            if (kingsResult > priestResult)
            {
                Score.Item1++;
                _kingWinText.SetActive(true);
                _priestWinText.SetActive(false);
                _kingLoseText.SetActive(false);
                _priestLoseText.SetActive(true);
            }
            else
            {
                Score.Item2++;
                _kingWinText.SetActive(false);
                _priestWinText.SetActive(true);
                _kingLoseText.SetActive(true);
                _priestLoseText.SetActive(false);
            }

            _scoreText.text = $"{Score.Item1} : {Score.Item2}";
        }

        private void FillKingResults()
        {
            var sprites = _king.GetFilledResourses();
            for (int i = 0; i < _kingResultSlots.Count; i++)
            {
                if (i < sprites.Count)
                {
                    _kingResultSlots[i].sprite = sprites[i];
                }
                else
                {
                    _kingResultSlots[i].sprite = _emptySprite;
                }
            }
        }

        private void FillPriestResults()
        {
            var sprites = _priest.GetFilledResourses();
            for (int i = 0; i < _priestResultSlots.Count; i++)
            {
                if (i < sprites.Count)
                {
                    _priestResultSlots[i].sprite = sprites[i];
                }
                else
                {
                    _priestResultSlots[i].sprite = _emptySprite;
                }
            }
        }

        public void Hide()
        {
            _window.SetActive(false);
        }
    }
}