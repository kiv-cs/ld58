using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Game : MonoBehaviour
    {
        public Village Village;
        public Calendar Calendar;
        public EnemyMoves Enemy;
        [SerializeField] private GameObject _beginYearPanel;


        private void Start()
        {
            Village.Initialize();
            _beginYearPanel.SetActive(true);
        }

        public void BeginYear()
        {
            Calendar.BeginYear();
            Enemy.BeginMoving();
            _beginYearPanel.SetActive(false);
        }
    }
}