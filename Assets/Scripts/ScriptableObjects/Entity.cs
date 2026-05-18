using UnityEngine;

namespace ScriptableObjects
{
    public class Entity : ScriptableObject
    {
        public float maxLife;
        public float defense;
        public float damage;
        public float moveSpeed;
        public float attackRate;
        public float immuneFrames;
    }
}