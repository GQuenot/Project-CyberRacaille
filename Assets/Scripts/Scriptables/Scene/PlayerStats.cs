using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/PlayerStats")]
public class PlayerStats : ScriptableObject
{ 
    public int Id;
    public float Speed = 10.0f;
    public int MaxHp = 10;
}
