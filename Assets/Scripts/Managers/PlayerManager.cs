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
        [HideInInspector]
        public Vector2 Movement { get; private set; } = Vector2.zero;
        [HideInInspector]
        public Vector2 Aim { get; private set; } = Vector2.zero;
        private Camera _camera;
        private float _xRotation;
        private float _ySensitivity = 30f;
        private float _xSensitivity = .1f;

        void OnEnable()
        {
            //Subscribe to our Input Action System
            _input = new PlayerInput();
            _input.Player.Enable();

            _input.Player.Move.performed += SetMove;
            _input.Player.Move.canceled += SetMove;

            _input.Player.Aim.performed += SetLook;
            _input.Player.Aim.canceled += SetLook;

            _input.Player.Inventory.started += ToggleInventory;

        }

        void Start()
        {
            _camera = Camera.main;
        }

        private void SetLook(InputAction.CallbackContext context)
        {
            Aim = context.ReadValue<Vector2>();
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
            //Update the movement of the player
            transform.position += new Vector3(Movement.x * Time.deltaTime * _playerStats.Speed, 0, Movement.y * Time.deltaTime * _playerStats.Speed);

            //update the rotation of the player according to the mousePos
            transform.Rotate(Vector3.up * Aim.x * _xSensitivity);
            _xRotation -= Aim.y * Time.deltaTime * _ySensitivity;
            _xRotation = Mathf.Clamp(_xRotation, -80, 80);
            _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        }

    }
}
