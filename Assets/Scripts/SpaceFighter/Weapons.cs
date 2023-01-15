using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceFighter
{
    public class Weapons : MonoBehaviour
    {
        [SerializeField] GameObject _bulletsGameObject;
        [SerializeField] WeaponDescription[] _weaponDescriptions;

        private List<Weapon> _weapons;

        private void Start()
        {
            _weapons = new List<Weapon>();
            foreach(var weaponDescription in _weaponDescriptions)
            {
                _weapons.Add(new Weapon(weaponDescription));
            }
        }

        private void Update()
        {
            foreach (var weapon in _weapons)
            {
                HandleWeapon(weapon);
            }
        }

        void HandleWeapon(Weapon weapon)
        {
            if (weapon != null)
            {
                weapon.Update(Time.deltaTime);
                if (weapon.IsReadyToFire())
                {
                    Fire(weapon);
                }
            }
        }

        void Fire(Weapon weapon)
        {
            Debug.Log("Fire");
            var weaponDescription = weapon.GetDescription();

            //Vector3 position, Quaternion rotation, Transform parent
            var newGO = Instantiate(weaponDescription.bulletPrefub, transform.position, new Quaternion(), _bulletsGameObject.transform);
            weapon.Reload();
        }
    }
} 

