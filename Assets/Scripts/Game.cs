using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Game : MonoBehaviour
    {
        public Village Village;
        public Calendar Calendar;
        public EnemyMoves Enemy;
        public PriestMoves Priest;
        [SerializeField] private GameObject _beginYearPanel;
        [SerializeField] private GameOverPanel _gameOverPanel;
        [SerializeField] private ResultWindow _resultWindow;
        private int _currentSeason;
        [SerializeField] private List<SeasonParams> _seasonParamsList;


        private void Start()
        {
            _gameOverPanel.gameObject.SetActive(false);
            _resultWindow.Hide();
            _beginYearPanel.SetActive(true);
        }

        public void BeginYear()
        {
            StartEverything();
            
            _beginYearPanel.SetActive(false);
            _gameOverPanel.gameObject.SetActive(false);
            
            _currentSeason = 0;
        }

        public void GameOver(ResourceType resourceType)
        {
            Village.Stop();
            Calendar.Stop();
            Enemy.Stop();

            _gameOverPanel.gameObject.SetActive(true);
            _gameOverPanel.Initialize(resourceType);
        }

        public void SeasonEnded()
        {
            Calendar.Stop();
            Enemy.Stop();
            Village.Stop();
            _resultWindow.Show();
        }

        public void NextSeason()
        {
            _resultWindow.Hide();
            
            _currentSeason++;

            if (_currentSeason == 3)
            {
                WinGame();
            }
            
            StartEverything();
        }

        private void StartEverything()
        {
            Calendar.RunYear();

            Enemy.ResetResourceCounters();
            Priest.ResetResourceCounters();

            Enemy.InitializeParametres(_seasonParamsList[_currentSeason].KingGreed,
                _seasonParamsList[_currentSeason].KingIntervals);
            Enemy.Continue();

            Village.InitializeParametres(_seasonParamsList[_currentSeason]);
            Village.SpawnInitialResourses();
        }

        private void WinGame()
        {
        }
    }

    [Serializable]
    public struct SeasonParams
    {
        public float KingGreed;
        public float KingIntervals;
        public int HumansCount;
        public int CoinsCount;
        public int ChickensCount;
        public int FlowersCount;
    }
}