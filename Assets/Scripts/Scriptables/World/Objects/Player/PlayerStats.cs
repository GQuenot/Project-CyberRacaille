using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Root
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/PlayerStats")]
    public class PlayerStats : ScriptableObject
    { 
        public int Id;
        public float Speed = 20.0f;
        public int MaxHp = 10;

        public float JumpForce;
    } 
}
