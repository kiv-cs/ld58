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
        private (int, int) _score = (0, 0);
        [SerializeField] private TextMeshProUGUI _scoreText;

        public void Show(string season)
        {
            _window.SetActive(true);
            //_title.text = $"{season} IS OVER";
            FillKingResults();
            FillPriestResults();

            var kingsResult = _king.GetFilledResourses().Count;
            var priestResult = _priest.GetFilledResourses().Count;

            if (kingsResult > priestResult)
            {
                _score.Item1++;
            }
            else
            {
                _score.Item2++;
            }

            _scoreText.text = $"{_score.Item1} : {_score.Item2}";
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
    }
}