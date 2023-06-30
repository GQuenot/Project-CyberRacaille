using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Root
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        //All managers are singleton
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
        }

        private PlayerInput _input;
        private GameObject _currentDisplayed;
        [SerializeField] private GameObject _inventory;
        [SerializeField] private GameObject _options;

        void OnEnable()
        {
            //Subscribe to our Input Action System
            _input = new PlayerInput();
            _input.Enable();

            _input.UI.Inventory.started += ToggleInventory;
            _input.UI.Options.started += ToggleOptions;
        }

        private void ToggleOptions(InputAction.CallbackContext context)
        {
            SetState(_options);
            GameManager.Instance.PauseTheGame();
        }

        private void ToggleInventory(InputAction.CallbackContext context)
        {
            SetState(_inventory);
        }

        void SetState(GameObject gameObject)
        {
            if (_currentDisplayed != null)
            {   
                //Desactivate the last object
                _currentDisplayed.SetActive(false);
                _currentDisplayed = gameObject;
                //Then activate it again
                _currentDisplayed.SetActive(true);
            } else
            {
                _currentDisplayed = gameObject;
                _currentDisplayed.SetActive(true);
            }
        }
    }
}
