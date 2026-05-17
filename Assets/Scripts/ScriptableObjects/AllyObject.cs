using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(
        fileName = "New Ally",
        menuName = "Entity/New Ally")]
    public class AllyObject : ScriptableObject
    {
        public float moveSpeed;
        public float attackRate;
        public float damage;

    }
}