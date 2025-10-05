using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ResourceCounter : MonoBehaviour
    {
        [SerializeField] private bool _isPriest;
        [SerializeField] private List<Image> _slots;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private Sprite _emptySprite;
        public int CurrentCount;
        [SerializeField] private Village _village;
        [SerializeField] private ResourceType Type;
        [SerializeField] private GameObject _buttonBack;

        private void Start()
        {
            _village = FindAnyObjectByType<Village>(FindObjectsInactive.Include);
            RedrawSlots();
            if (_isPriest) _buttonBack.GetComponent<Button>().interactable = false;
        }

        public void Take()
        {
            if (CurrentCount < 5)
            {
                CurrentCount++;
                _village.RemoveResourceOfType(Type, _isPriest);
            }
            
            if (_isPriest) _buttonBack.GetComponent<Button>().interactable = (CurrentCount > 0);

            RedrawSlots();
        }

        public void Return()
        {
            if (CurrentCount > 0)
            {
                CurrentCount--;
                _village.AddResourceOfType(Type, _isPriest);
            }
            
            
            if (_isPriest) _buttonBack.GetComponent<Button>().interactable = (CurrentCount > 0);
            
            
            RedrawSlots();
        }

        private void RedrawSlots()
        {
            for (int i = 0; i < 5; i++)
            {
                _slots[i].sprite = i < CurrentCount ? _sprite : _emptySprite;
            }
        }

        public List<Sprite> GetFilledSprites()
        {
            var result = new List<Sprite>();
            foreach (var slot in _slots)
            {
                if (slot.sprite != _emptySprite)
                {
                    result.Add(slot.sprite);
                }
            }

            return result;
        }

        public void Reset()
        {
            CurrentCount = 0;
            RedrawSlots();
        }
    }

    public enum ResourceType
    {
        Human = 0,
        Coin = 10,
        Chicken = 20,
        Flower = 30
    }
}