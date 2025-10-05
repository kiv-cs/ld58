using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Village : MonoBehaviour
    {
        [SerializeField] private int _humanCount;
        [SerializeField] private int _coinCount;
        [SerializeField] private int _chickenCount;
        [SerializeField] private int _flowerCount;

        [SerializeField] private GameObject _humanPrefab;
        [SerializeField] private GameObject _coinPrefab;
        [SerializeField] private GameObject _chickenPrefab;
        [SerializeField] private GameObject _flowerPrefab;

        [SerializeField] public Transform BottomLeft;
        [SerializeField] public Transform TopRight;
        [SerializeField] private List<IResource> _resources = new();

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            SpawnInitialResourses();
        }

        private void SpawnInitialResourses()
        {
            for (int i = 0; i < _humanCount; i++) Spawn(ResourceType.Human);
            for (int i = 0; i < _coinCount; i++) Spawn(ResourceType.Coin);
            for (int i = 0; i < _chickenCount; i++) Spawn(ResourceType.Chicken);
            for (int i = 0; i < _flowerCount; i++) Spawn(ResourceType.Flower);
        }

        private void Spawn(ResourceType type)
        {
            GameObject prefab = null;
            switch (type)
            {
                case ResourceType.Human:
                    prefab = _humanPrefab;
                    break;
                case ResourceType.Coin:
                    prefab = _coinPrefab;
                    break;
                case ResourceType.Chicken:
                    prefab = _chickenPrefab;
                    break;
                case ResourceType.Flower:
                    prefab = _flowerPrefab;
                    break;
            }

            var x = Random.Range(BottomLeft.position.x, TopRight.position.x);
            var y = Random.Range(BottomLeft.position.y, TopRight.position.y);

            var resourceObject = Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);
            var resource = resourceObject.GetComponent<IResource>();
            resource.Initialize(this);

            _resources.Add(resource);
        }

        public void RemoveResourceOfType(ResourceType type)
        {
            switch (type)
            {
                case ResourceType.Human:
                    _humanCount--;
                    if(_humanCount <= 0) GameOver();
                    break;
                case ResourceType.Coin:
                    _coinCount--;
                    if(_coinCount <= 0) GameOver();
                    break;
                case ResourceType.Chicken:
                    _coinCount--;
                    if(_coinCount <= 0) GameOver();
                    break;
                case ResourceType.Flower:
                    _flowerCount--;
                    if(_flowerCount <= 0) GameOver();
                    break;
            }

            IResource resource = _resources.FirstOrDefault(x => x.Type == type);
            _resources.Remove(resource);
            if (resource != null) Destroy(resource.GameObject);
        }

        private void GameOver()
        {
        }

        public void AddResourceOfType(ResourceType type)
        {
            switch (type)
            {
                case ResourceType.Human:
                    _humanCount++;
                    break;
                case ResourceType.Coin:
                    _coinCount++;
                    break;
                case ResourceType.Chicken:
                    _chickenCount++;
                    break;
                case ResourceType.Flower:
                    _flowerCount++;
                    break;
            }
            
            Spawn(type);
        }
    }

    public interface IResource
    {
        void Initialize(Village village);
        ResourceType Type { get; set; }
        GameObject GameObject { get; set; }
    }
}