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
        [SerializeField] private Canvas _inventoryCanvas;
        [SerializeField] private Canvas _optionsCanvas;

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
            _optionsCanvas.gameObject.SetActive(!_optionsCanvas.isActiveAndEnabled);
        }

        private void ToggleInventory(InputAction.CallbackContext context)
        {
            _inventoryCanvas.gameObject.SetActive(!_inventoryCanvas.isActiveAndEnabled);
        }
    }
}
