using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Root
{
    public class EnemyBehavior : MonoBehaviour
    {
        public EnemyReference EnemyReference;
        public LifeBar LifeBar;

        //Will be used everytime we trigger an event that change the lifeReference
        public void CheckIfAlive()
        {
            if (EnemyReference.CurrentHp > 0)
            {
                return;
            } else
            {
                XPManager.Instance.AddXp(EnemyReference);
                Destroy(gameObject);
            }
        }

        void Awake()
        {
            EnemyReference.CurrentHp = EnemyReference.MaxHp;
        }
    }
}
