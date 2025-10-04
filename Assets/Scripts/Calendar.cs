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

        private void Start()
        {
            BeginYear();
            InitializeSlider();
        }

        private void InitializeSlider()
        {
            _slider.maxValue = 400;
        }

        public void BeginYear()
        {
            _yearCo = StartCoroutine(YearCo());
            BeginSummer();
        }

        private void BeginSummer()
        {
        }

        private void BeginAutumn()
        {
        }

        private void BeginWinter()
        {
        }

        private void BeginSpring()
        {
        }

        private void EndYear()
        {
        }

        private IEnumerator YearCo()
        {
            while (_isWorking)
            {
                yield return new WaitForSeconds(1f / _speed);
                _currentDay++;

                _slider.value = _currentDay;

                if (_currentDay == 100)
                    BeginAutumn();

                if (_currentDay == 200)
                    BeginWinter();

                if (_currentDay == 300)
                    BeginSpring();

                if (_currentDay == 400)
                    EndYear();
            }
        }
    }
}