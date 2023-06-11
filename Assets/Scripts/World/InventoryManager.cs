using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Root
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField]
        private InventoryMeta _inventoryMeta;
        [SerializeField]
        private GameObject _itemPrefab;
        void Awake()
        {
            foreach (var item in _inventoryMeta.Items)
            {
                GameObject gameObject = Instantiate<GameObject>(_itemPrefab);
                gameObject.transform.SetParent(transform);

                Image imageComponent = gameObject.GetComponentInChildren<Image>();
                if (imageComponent != null)
                    imageComponent.sprite = item.Image;

                TextMeshProUGUI tmproComponent = gameObject.GetComponentInChildren<TextMeshProUGUI>();
                if (tmproComponent != null)
                    tmproComponent.text = item.Name;
            }
        }
    }
}
