using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Root
{
    [CreateAssetMenu(fileName = "InventoryMeta", menuName = "Inventory/InventoryMeta")]
    public class InventoryMeta : ScriptableObject
    { 
        public int Id;
        public int MaxItems = 20;
        public int Coins = 0;
        public List<Item> Items;
    } 
}
