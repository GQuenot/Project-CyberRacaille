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
        [HideInInspector]
        public Vector2 Movement { get; private set; } = Vector2.zero;
        [HideInInspector]
        public Vector2 Aim { get; private set; } = Vector2.zero;
        private Camera _camera;
        private float _xRotation;
        private float maxVelDelta = 1;
        [SerializeField]
        private Rigidbody _rb;
        [SerializeField] Animator _weaponAnimator;
        [SerializeField] PlayerSettings _playerSettings;
        private bool _isTouchingGround = false;

        void OnEnable()
        {
            //Subscribe to our Input Action System
            _input = new PlayerInput();
            _input.Player.Enable();

            _input.Player.Move.performed += SetMove;
            _input.Player.Move.canceled += SetMove;

            _input.Player.Aim.performed += SetLook;
            _input.Player.Aim.canceled += SetLook;

            _input.Player.Attack.started += PerformAttack;

            _input.Player.Jump.started += PerformJump;

        }

        private void PerformJump(InputAction.CallbackContext context)
        {
            if (_isTouchingGround)
            {
                _rb.AddForce(new Vector3(0, 1 * _playerStats.JumpForce, 0), ForceMode.Impulse);
                _isTouchingGround = false;
            }
        }

        private void PerformAttack(InputAction.CallbackContext context)
        {
            _weaponAnimator.SetTrigger("SwingTrigger");
        }

        void Start()
        {
            _camera = Camera.main;
        }

        private void SetLook(InputAction.CallbackContext context)
        {
            Aim = context.ReadValue<Vector2>();
        }

        private void SetMove(InputAction.CallbackContext context)
        {
            Movement = context.ReadValue<Vector2>();
        }

        void OnDisable()
        {
            _input.Player.Disable();
        }

        private void OnCollisionEnter(Collision collision)
        {
            //Important to name every ground object Ground
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isTouchingGround = true;
            } else if (collision == null)
            {
                _isTouchingGround = false;
            }
        }

        void FixedUpdate()
        {
            Move();

            Rotate();
        }

        private void Move()
        {
            //Find target velocity
            Vector3 currentVelocity = _rb.velocity;
            //Vector3 targetVelocity = new Vector3(Movement.x, 0, Movement.y);
            Vector3 targetVelocity = new Vector3(Movement.x, currentVelocity.y, Movement.y);
            
            targetVelocity = new Vector3(targetVelocity.x * _playerStats.Speed, targetVelocity.y, targetVelocity.z * _playerStats.Speed);

            //Align directions
            targetVelocity = transform.TransformDirection(targetVelocity);

            //Calculate the forces 
            Vector3 velocityDelta = targetVelocity - currentVelocity;

            //Limit force 
            Vector3.ClampMagnitude(velocityDelta, maxVelDelta);

            //Apply force
            _rb.AddForce(velocityDelta, ForceMode.VelocityChange);
        }

        private void Rotate()
        {
            //update the rotation of the player according to the mousePos
            transform.Rotate(Vector3.up * Aim.x * _playerSettings.XSensibility);

            _xRotation -= Aim.y * Time.deltaTime * _playerSettings.YSensibility;
            _xRotation = Mathf.Clamp(_xRotation, -80, 80);
            _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        }

    }
}
