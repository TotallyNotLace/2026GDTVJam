using UnityEngine;

namespace ScriptableObjects
{
        [CreateAssetMenu(
        fileName = "New Projectile",
        menuName = "Entity/New Projectile")]
    public class ProjectileObject : ScriptableObject
    {
        public float damage;
        public float moveSpeed;
        public float spinSpeed;
    }
}
