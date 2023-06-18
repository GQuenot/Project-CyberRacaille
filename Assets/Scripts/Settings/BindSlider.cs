using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Root
{
    public class BindSlider : MonoBehaviour
    {
        [SerializeField] private PlayerSettings _playerSettings;
        [SerializeField] private float _max;
        private Slider _slider;
        [SerializeField] private Axis _axis;
        private enum Axis 
        {
            XSensibility,
            YSensibility
        }

        void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        void Start()
        {
            switch (_axis)
            {
                case Axis.XSensibility:
                    _slider.value = _playerSettings.XSensibility / _max;
                    break;
                case Axis.YSensibility:
                    _slider.value = _playerSettings.YSensibility / _max;
                    break;
                default:
                    Debug.Log("Axis not definied");
                    break;
            }
        }

        public void BindValue()
        {
            switch (_axis)
            {
                case Axis.XSensibility:
                    _playerSettings.XSensibility = _slider.value * _max;
                    break;
                case Axis.YSensibility:
                    _playerSettings.YSensibility = _slider.value * _max;
                    break;
                default:
                    Debug.Log("Axis not definied");
                    break;
            }
        }

    }
}
