using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Root
{
    public class EnnemiBehavior : MonoBehaviour
    {
        public EnnemiReference EnnemiReference;
        public LifeBar LifeBar;

        //Will be used everytime we trigger an event that change the lifeReference
        public void CheckIfAlive()
        {
            if (EnnemiReference.CurrentHp > 0)
            {
                return;
            } else
            {
                Destroy(gameObject);
            }
        }

        void Awake()
        {
            EnnemiReference.CurrentHp = EnnemiReference.MaxHp;
        }
    }
}
