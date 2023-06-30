using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Root
{
    public class UIBaseState : BaseState
    {
        private UISM _smUI;

        public UIBaseState(UISM stateMachine) : base("BaseState", stateMachine)
        {
            _smUI = (UISM)stateMachine;
        }
        public override void OnEnter()
        {
            base.OnEnter();

            _smUI.Input.UI.Inventory.started += ToggleInventory;
            _smUI.Input.UI.Options.started += ToggleOptions;
        }

        private void ToggleOptions(InputAction.CallbackContext context)
        {
            //Deactivate the current gameObject
            _smUI.CurrentState?.SetActive(false);
            //Reassign
            _smUI.CurrentState = _smUI.Options;
            _smUI.CurrentState.SetActive(true);
        }

        private void ToggleInventory(InputAction.CallbackContext context)
        {
            //Deactivate the current gameObject
            _smUI.CurrentState?.SetActive(false);
            //Reassign
            _smUI.CurrentState = _smUI.Inventory;
            _smUI.CurrentState.SetActive(true);
        }

        public override void Update()
        {
            base.Update();
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }
        public override void OnExit()
        {
            base.OnExit();
        }
    }
}
