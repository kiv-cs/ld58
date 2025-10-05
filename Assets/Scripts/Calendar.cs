using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Calendar : MonoBehaviour
    {
        private Coroutine _yearCo;
        [SerializeField] private float _speed = 1f;
        [SerializeField] private int _currentDay;
        [SerializeField] private bool _isWorking;
        [SerializeField] private Slider _slider;
        [SerializeField] private ResultWindow _resultWindow;
        [SerializeField] private Game _game;

        private void Start()
        {
            InitializeSlider();
        }

        private void InitializeSlider()
        {
            _slider.maxValue = 300;
        }
        
        public void RunYear()
        {
            _yearCo = StartCoroutine(YearCo());
        }

        private void OpenResultWindow()
        {
            _game.SeasonEnded();
        }

        private void EndSeason()
        {
            OpenResultWindow();
        }

        private IEnumerator YearCo()
        {
            while (_isWorking)
            {
                yield return new WaitForSeconds(1f / _speed);
                _currentDay++;

                _slider.value = _currentDay;

                if (_currentDay == 100)
                    EndSeason();

                if (_currentDay == 200)
                    EndSeason();

                if (_currentDay == 300)
                    EndSeason();
            }
        }

        public void Stop()
        {
            StopCoroutine(_yearCo);
        }

        public void SetSeason(int currentSeason)
        {
            _currentDay = currentSeason * 100;
        }
    }
}