using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Coin : MonoBehaviour, IResource
    {
        [SerializeField] private ResourceType _type;

        public void Initialize(Village village)
        {
            Type = _type;
            GameObject = gameObject;
        }

        public ResourceType Type { get; set; }
        public GameObject GameObject { get; set; }
    }
}