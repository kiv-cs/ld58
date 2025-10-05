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

        private void Start()
        {
            InitializeSlider();
        }

        private void InitializeSlider()
        {
            _slider.maxValue = 300;
        }

        public void BeginYear()
        {
            _yearCo = StartCoroutine(YearCo());
            BeginSummer();
        }

        private void BeginSummer()
        {
        }

        private void EndSummer()
        {
            OpenResultWindow("SUMMER");
        }

        private void EndAutumn()
        {
            OpenResultWindow("AUTUMN");
        }

        private void EndWinter()
        {
            OpenResultWindow("WINTER");
        }

        private void EndYear()
        {
        }

        private void OpenResultWindow(string season)
        {
            _resultWindow.Show(season);
        }

        private IEnumerator YearCo()
        {
            while (_isWorking)
            {
                yield return new WaitForSeconds(1f / _speed);
                _currentDay++;

                _slider.value = _currentDay;

                if (_currentDay == 100)
                    EndSummer();

                if (_currentDay == 200)
                    EndAutumn();

                if (_currentDay == 300)
                    EndYear();
            }
        }
    }
}