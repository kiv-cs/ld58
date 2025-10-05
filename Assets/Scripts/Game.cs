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
        [SerializeField] private GameOverPanel _gameOverPanel;


        private void Start()
        {
            Village.Initialize();
            _gameOverPanel.gameObject.SetActive(false);
            _beginYearPanel.SetActive(true);
        }

        public void BeginYear()
        {
            Calendar.BeginYear();
            Enemy.BeginMoving();
            _beginYearPanel.SetActive(false);
            _gameOverPanel.gameObject.SetActive(false);
        }

        public void GameOver(ResourceType resourceType)
        {
            Village.Stop();
            Calendar.Stop();
            Enemy.Stop();

            _gameOverPanel.gameObject.SetActive(true);
            _gameOverPanel.Initialize(resourceType);
        }
    }
}