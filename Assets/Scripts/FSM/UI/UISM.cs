using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Root
{
    public class UISM : StateMachine
    {
        
        #region Input
        public PlayerInput Input;

        void OnEnable()
        {
            //Subscribe to our Input Action System
            Input = new PlayerInput();
            Input.Enable();
        }
        #endregion
        public GameObject CurrentState;
        public GameObject Options;
        public GameObject Inventory;
        public UIBaseState BaseState;
        void Awake()
        {
            BaseState = new UIBaseState(this);
        }
        protected override BaseState GetInitialState()
        {
            return BaseState;
        }

    }
}
