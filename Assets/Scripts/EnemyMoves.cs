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
        private Coroutine _moveCo;
        [SerializeField] private bool _isWorking = true;

        private void Start()
        {
            BeginMoving();
        }

        public void BeginMoving()
        {
            _moveCo = StartCoroutine(MoveCo());
        }

        private void MoveRandom()
        {
            var resourceIndex = Random.Range(0, _resources.Count);
            if (Random.value < .5f)
                _resources[resourceIndex].Add();
            else
                _resources[resourceIndex].Remove();
        }

        private IEnumerator MoveCo()
        {
            while (_isWorking)
            {
                yield return new WaitForSeconds(_interval);
                MoveRandom();
            }
        }
    }
}