using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Root
{
    [CreateAssetMenu(fileName = "EnemyReference", menuName = "Enemy/EnemyReference")]
    public class EnemyReference : ScriptableObject
    {
        public int Id;
        public int CurrentHp;
        public int MaxHp;
        public int XP;
    }
}
