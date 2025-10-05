using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class Chicken : MonoBehaviour, IResource
    {
        private Village _village;
        [SerializeField] private float _speed = 1f;
        [SerializeField] private ResourceType _type;

        public void Initialize(Village village)
        {
            Type = _type;
            GameObject = gameObject;
            _village = village;
            StartMoving();
        }

        public ResourceType Type { get; set; }
        public GameObject GameObject { get; set; }

        private void StartMoving()
        {
            var x = Random.Range(_village.BottomLeft.position.x, _village.TopRight.position.x);
            var y = Random.Range(_village.BottomLeft.position.y, _village.TopRight.position.y);

            Vector3 target = new Vector3(x, y, 0);
            float time = Vector3.Distance(transform.position, target) / _speed;
            float delay = Random.Range(1f, 3f);
            transform.DOMove(target, time).SetDelay(delay).OnComplete(StartMoving).SetEase(Ease.Linear);
        }
    }
}