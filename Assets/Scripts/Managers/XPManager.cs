using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Root
{
    public class XPManager : MonoBehaviour
    {
        public static XPManager Instance;
        void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
            } else
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }

            //The manager needs to check for how much xp is necessary
            _playerStats.CheckForLevelUp();
        }
        [SerializeField] private PlayerStats _playerStats;
        [SerializeField] private GameEvent _levelUp;
 
        public void AddXp(EnemyReference enemyReference)
        {
            _playerStats.CurrentXp += enemyReference.XP;
            bool levelUp = _playerStats.CheckForLevelUp();
            if (levelUp) {_levelUp.Raise(); }
        }
        //If ennemy dies we add the xp to our current

        //Then we check for level up
    }
}
