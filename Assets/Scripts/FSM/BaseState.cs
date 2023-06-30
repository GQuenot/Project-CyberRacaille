using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Root
{
    public class BaseState
    {
        protected StateMachine _sm;
        public string Name;
        public BaseState(string name, StateMachine stateMachine)
        {
            Name = name;
            _sm = stateMachine;
        }

        public virtual void OnEnter() {}
        public virtual void Update() {}
        public virtual void FixedUpdate() {}
        public virtual void OnExit() {}
    }
}
