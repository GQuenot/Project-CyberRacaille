using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Root
{
    public class StateMachine : MonoBehaviour
    {
        public BaseState Current;

        void Start()
        {
            Current = GetInitialState();
            Current?.OnEnter();
        }

        void Update()
        {
            Current?.Update();
        }

        void FixedUpdate()
        {
            Current?.FixedUpdate();
        }

        public void ChangeState(BaseState newState)
        {
            Current.OnExit();

            Current = newState;
            Current.OnEnter();
        }

        protected virtual BaseState GetInitialState()
        {
            return null;
        }
    }
}
