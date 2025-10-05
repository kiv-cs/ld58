using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Game : MonoBehaviour
    {
        public Village Village;

        private void Start()
        {
            Village.Initialize();
        }
    }
}