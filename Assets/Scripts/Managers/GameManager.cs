using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Root
{
    public class GameManager : MonoBehaviour
    { 
        public static GameManager Instance;
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

            _isPaused = false;
        }

        private PlayerInput _playerInput;
        [SerializeField] GameEvent _pauseEvent; 
        [SerializeField] GameEvent _resumeEvent;
        public bool _isPaused;
        void OnEnable()
        {
            _playerInput = new PlayerInput();
            _playerInput.Enable();

            _playerInput.UI.Options.started += PauseTheGame;
        }

        private void PauseTheGame(InputAction.CallbackContext context)
        {
            if (_isPaused) 
            {
                _isPaused = false;
                _resumeEvent.Raise();
            } else
            {
                _isPaused = true;
                _pauseEvent.Raise();
            }
        }

        public void PauseTheTime()
        {
            _isPaused = true;
            Time.timeScale = 0;
        }
        
        public void ResumeTheTime()
        {
            _isPaused = false;
            Time.timeScale = 1;
        }
    }
}
