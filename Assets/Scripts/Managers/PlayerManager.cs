using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Root
{
    public class PlayerManager : MonoBehaviour
    {
        private PlayerInput _input;
        [SerializeField]
        private PlayerStats _playerStats;
        [SerializeField]
        private Canvas _inventoryCanvas;
        public Vector2 Movement {get; private set;} = Vector2.zero;

        void OnEnable()
        {
            //Subscribe to our Input Action System
            _input = new PlayerInput();
            _input.Player.Enable();

            _input.Player.Move.performed += SetMove;
            _input.Player.Move.canceled += SetMove;

            _input.Player.Inventory.started += ToggleInventory;

        }

        private void ToggleInventory(InputAction.CallbackContext context)
        {
            _inventoryCanvas.gameObject.SetActive(!_inventoryCanvas.isActiveAndEnabled);
        }

        private void SetMove(InputAction.CallbackContext context)
        {
            Movement = context.ReadValue<Vector2>();
        }

        void OnDisable()
        {
            _input.Player.Disable();
        }

        void Update()
        {
            transform.position += new Vector3(Movement.x * Time.deltaTime * _playerStats.Speed, 0, Movement.y * Time.deltaTime * _playerStats.Speed);
        }

    }
}
