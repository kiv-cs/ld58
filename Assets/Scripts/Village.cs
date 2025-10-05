using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
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
        [SerializeField] private SplashesAnimator _splashAnimator;
        [SerializeField] private Animator _cameraShaker;
        [SerializeField] private Game _game;
        [SerializeField] private Transform _priestTarget;
        [SerializeField] private Transform _kingTarget;

        public void Initialize()
        {
            SpawnInitialResourses();
        }

        public void SpawnInitialResourses()
        {
            _resources.Clear();
            for (int i = 0; i < _humanCount; i++) Spawn(ResourceType.Human);
            for (int i = 0; i < _coinCount; i++) Spawn(ResourceType.Coin);
            for (int i = 0; i < _chickenCount; i++) Spawn(ResourceType.Chicken);
            for (int i = 0; i < _flowerCount; i++) Spawn(ResourceType.Flower);
        }

        private IResource Spawn(ResourceType type)
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
            
            return resource;
        }
        
        private IResource SpawnAdding(ResourceType type, bool isPriest)
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

            var target = new Vector3(x, y, 0);
            var spawnPoint = isPriest ? _priestTarget.position : _kingTarget.position;

            var resourceObject = Instantiate(prefab, spawnPoint, Quaternion.identity);
            var resource = resourceObject.GetComponent<IResource>();
            resource.Initialize(this);

            _resources.Add(resource);

            resource.GameObject.transform.DOMove(target, .6f).OnComplete(() =>
            {
                //_splashAnimator.PlaySplash(resource.GameObject.transform.position, isPriest, true);
            });

            return resource;
        }

        public void RemoveResourceOfType(ResourceType type, bool isPriest)
        {
            switch (type)
            {
                case ResourceType.Human:
                    _humanCount--;
                    if(_humanCount <= 0) GameOver(ResourceType.Human);
                    break;
                case ResourceType.Coin:
                    _coinCount--;
                    if(_coinCount <= 0) GameOver(ResourceType.Coin);
                    break;
                case ResourceType.Chicken:
                    _chickenCount--;
                    if(_chickenCount <= 0) GameOver(ResourceType.Chicken);
                    break;
                case ResourceType.Flower:
                    _flowerCount--;
                    if(_flowerCount <= 0) GameOver(ResourceType.Flower);
                    break;
            }

            IResource resource = _resources.FirstOrDefault(x => x.Type == type);
            _resources.Remove(resource);

            _splashAnimator.PlaySplash(resource.GameObject.transform.position, isPriest, false);

            if (resource != null)
            {
                var target = isPriest ? _priestTarget : _kingTarget;
                resource.GameObject.transform.DOMove(target.position, .5f);
                Destroy(resource.GameObject, .5f);
            }
            
            _cameraShaker.speed = 1;
            _cameraShaker.Play("camera-shake");
            
        }

        private void GameOver(ResourceType resourceType)
        {
            _game.GameOver(resourceType);
        }

        public void AddResourceOfType(ResourceType type, bool isPriest)
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
            
            var resource = SpawnAdding(type, isPriest);
            
            

            //_cameraShaker.speed = 1;
            //_cameraShaker.Play("camera-shake");
        }

        public void Stop()
        {
            foreach (var resource in _resources)
            {
                Destroy(resource.GameObject);
            }
        }

        public void InitializeParametres(SeasonParams seasonParams)
        {
            _humanCount = seasonParams.HumansCount;
            _coinCount = seasonParams.CoinsCount;
            _chickenCount = seasonParams.ChickensCount;
            _flowerCount = seasonParams.FlowersCount;
        }
    }

    public interface IResource
    {
        void Initialize(Village village);
        ResourceType Type { get; set; }
        GameObject GameObject { get; set; }
    }
}