using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Root
{
    [CreateAssetMenu(fileName = "Dialog", menuName = "NPC/Dialog")]
    public class Dialog : ScriptableObject
    { 
        public int Id;
        public string Line;
        public List<string> Answers;
    } 
}
