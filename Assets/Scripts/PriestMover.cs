using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class PriestMoves : MonoBehaviour
    {
        [SerializeField] private List<ResourceCounter> _resources;

        public List<Sprite> GetFilledResourses()
        {
            var result = new List<Sprite>();
            foreach (var resource in _resources)
            {
                result.AddRange(resource.GetFilledSprites());
            }

            return result;
        }
    }
}