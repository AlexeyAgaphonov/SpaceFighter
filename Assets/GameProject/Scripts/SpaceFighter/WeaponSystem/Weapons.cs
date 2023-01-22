using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;



namespace SpaceFighter
{
    public class Weapons : MonoBehaviour
    {
        [Inject (Id = "BulletsContainer")] GameObject _bulletsGameObject;
        [SerializeField] WeaponDescription[] _weaponDescriptions;

        private List<Weapon> _weapons;

        [SerializeField] private bool _isFiring;
        public bool IsFiring => _isFiring;

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
                if (IsFiring && weapon.IsReadyToFire())
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
            newGO.tag = tag;
            weapon.Reload();
        }

        public void StartFiring()
        {
            _isFiring = true;
        }

        public void FinishFiring()
        {
            _isFiring = false;
        }
    }
} 
