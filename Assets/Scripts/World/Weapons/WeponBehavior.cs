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
                EnnemiBehavior ennemiBehavior = collider.gameObject.GetComponent<EnnemiBehavior>();
                ennemiBehavior.EnnemiReference.CurrentHp -= 8;
                ennemiBehavior.LifeBar.SetLifeBarSlider();
                ennemiBehavior.CheckIfAlive();
            }
        }
    }
}
