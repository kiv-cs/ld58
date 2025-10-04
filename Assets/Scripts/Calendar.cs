using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class Calendar : MonoBehaviour
    {
        private Coroutine _yearCo;
        [SerializeField] private float _speed = 1f;
        [SerializeField] private int _currentDay;

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
            yield return new WaitForSeconds(1f * _speed);
            _currentDay++;
            
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