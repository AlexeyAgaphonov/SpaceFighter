using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceFighter
{
    public enum WeaponType
    {
        BulletSpawner
    }

    [CreateAssetMenu(menuName = "SpaceFighter/WeaponDescription")]
    public class WeaponDescription : ScriptableObject
    {
        public GameObject bulletPrefub;
        public BulletDescription bulletDescription;
        public float cooldownAttack;
        public float bulletSpeed;
        public WeaponType weaponType;
    }
}
