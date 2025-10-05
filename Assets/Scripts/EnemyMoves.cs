using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class EnemyMoves : MonoBehaviour
    {
        [SerializeField] private List<ResourceCounter> _resources;
        [SerializeField] private float _interval = 3;
        [SerializeField] private float _greed = .6f;
        private Coroutine _moveCo;
        [SerializeField] private bool _isWorking = true;

        public void BeginMoving()
        {
            _moveCo = StartCoroutine(MoveCo());
        }

        private void MoveRandom()
        {
            var resourceIndex = Random.Range(0, _resources.Count);
            if (Random.value < _greed)
                _resources[resourceIndex].Take();
            else
                _resources[resourceIndex].Return();
        }

        private IEnumerator MoveCo()
        {
            while (_isWorking)
            {
                yield return new WaitForSeconds(_interval);
                MoveRandom();
            }
        }

        public List<Sprite> GetFilledResourses()
        {
            var result = new List<Sprite>();
            foreach (var resource in _resources)
            {
                result.AddRange(resource.GetFilledSprites());
            }

            return result;
        }

        public void Stop()
        {
            StopCoroutine(_moveCo);
        }

        public void Continue()
        {
            _moveCo = StartCoroutine(MoveCo());
        }

        public void InitializeParametres(float kingGreed, float kingIntervals)
        {
            _greed = kingGreed;
            _interval = kingIntervals;
        }

        public void ResetResourceCounters()
        {
            foreach (var resource in _resources)
            {
                resource.Reset();
            }
        }
    }
}