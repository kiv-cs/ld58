using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] private Image _resourceImage;
        [SerializeField] private Sprite _humanSprite;
        [SerializeField] private Sprite _coinSprite;
        [SerializeField] private Sprite _chickenSorite;
        [SerializeField] private Sprite _flowerSprite;

        public void Initialize(ResourceType resourceType)
        {
            switch (resourceType)
            {
                case ResourceType.Human:
                    _resourceImage.sprite = _humanSprite;
                    break;
                case ResourceType.Coin:
                    _resourceImage.sprite = _coinSprite;
                    break;
                case ResourceType.Chicken:
                    _resourceImage.sprite = _chickenSorite;
                    break;
                case ResourceType.Flower:
                    _resourceImage.sprite = _flowerSprite;
                    break;
            }
        }

        public void Reset()
        {
            SceneManager.LoadScene(0);
        }
    }
}