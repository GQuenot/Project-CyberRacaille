using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Root
{
    public class LifeBar : MonoBehaviour
    {
        [SerializeField] private EnemyReference _enemyReference;
        private Slider _lifeSlider;
        // Start is called before the first frame update
        void Awake()
        {
            _lifeSlider = gameObject.GetComponent<Slider>();
        }

        public void SetLifeBarSlider()
        {
            _lifeSlider.value = (float)_enemyReference.CurrentHp / (float)_enemyReference.MaxHp;
        }
    }
}
