using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Root
{
    public class WeponBehavior : MonoBehaviour
    {
        void OnTriggerEnter(Collider collider)
        {
            if (collider.CompareTag("Ennemi"))
            {
                EnemyBehavior ennemiBehavior = collider.gameObject.GetComponent<EnemyBehavior>();
                ennemiBehavior.EnemyReference.CurrentHp -= 8;
                ennemiBehavior.LifeBar.SetLifeBarSlider();
                ennemiBehavior.CheckIfAlive();
            }
        }
    }
}
