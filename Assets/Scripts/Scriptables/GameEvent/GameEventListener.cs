using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Root
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent Event;
        public UnityEvent Response;
        public void OnEnable()
        { Event.RegisterListener(this); }
        public void OnDisable()
        { Event.UnregisterListener(this); }
        public void OnEventRaised()
        { Response.Invoke(); }
    }
}