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
        public int Level;
        public int CurrentXp;
        public int TotalXp;
        public int BaseXp;
        public int _necessaryXp;

        public bool CheckForLevelUp()
        {
            int sup = CurrentXp - _necessaryXp;
            if (sup >= 0)
            {
                Level++;
                CurrentXp = sup;
                Debug.Log(sup);
                //We then calculate immediately the xp required for next lvl
                _necessaryXp = LevelUpXpRequired(Level);

                return true;
            }

            return false;
        }

        public int LevelUpXpRequired(int level)
        {
            //1.1 is an arbitrary value that means that we will need always 110% of the last level
            int xp = Mathf.RoundToInt(BaseXp *  Mathf.Pow(level, 1.1f));
            Debug.Log(xp);
            return xp;
        }
    } 
}
