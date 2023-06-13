using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Root
{
    [CreateAssetMenu(fileName = "EnnemiReference", menuName = "Ennemi/EnnemiReference")]
    public class EnnemiReference : ScriptableObject
    {
        public int Id;
        public int CurrentHp;
        public int MaxHp;
    }
}
