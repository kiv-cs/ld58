using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ResourceCounter : MonoBehaviour
    {
        [SerializeField] private List<Image> _slots;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private Sprite _emptySprite;
        public int CurrentCount;

        private void Start()
        {
            RedrawSlots();
        }

        public void Add()
        {
            if (CurrentCount < 5)
            {
                CurrentCount++;
            }

            RedrawSlots();
        }

        public void Remove()
        {
            if (CurrentCount > 0)
            {
                CurrentCount--;
            }
            RedrawSlots();
        }

        private void RedrawSlots()
        {
            for (int i = 0; i < 5; i++)
            {
                _slots[i].sprite = i < CurrentCount ? _sprite : _emptySprite;
            }
        }
    }
}