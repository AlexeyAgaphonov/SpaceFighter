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
        public float cooldownAttack;
        public WeaponType weaponType;
    }
}
