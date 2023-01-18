using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceFighter
{
    [CreateAssetMenu(menuName = "SpaceFighter/BulletDescription")]
    public class BulletDescription : ScriptableObject
    {
        public float speed;
        public float lifetime;
        public float damage;
    }
}
