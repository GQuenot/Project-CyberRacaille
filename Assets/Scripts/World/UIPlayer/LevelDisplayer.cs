using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Root
{
    public class LevelDisplayer : MonoBehaviour
    {
        [SerializeField] private PlayerStats _playerStats;
        private TextMeshProUGUI _tmpro;

        void Awake()
        {
            _tmpro = gameObject.GetComponent<TextMeshProUGUI>();
        }
        void Start()
        {
            _tmpro.text = $"level : {_playerStats.Level}";
        }

        public void UpdateLevelDisplay()
        {
            _tmpro.text = $"level : {_playerStats.Level}";
        }
    }
}
