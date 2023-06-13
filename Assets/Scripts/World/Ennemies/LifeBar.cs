using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Root
{
    public class LifeBar : MonoBehaviour
    {
        [SerializeField] private EnnemiReference _ennemiReference;
        private Slider _lifeSlider;
        // Start is called before the first frame update
        void Awake()
        {
            _lifeSlider = gameObject.GetComponent<Slider>();
        }

        public void SetLifeBarSlider()
        {
            _lifeSlider.value = (float)_ennemiReference.CurrentHp / (float)_ennemiReference.MaxHp;
        }
    }
}
