using System.Collections;
using System.Collections.Generic;
using DI;
using UnityEngine;
using Zenject;


namespace SpaceFighter
{
    public class Weapons : MonoBehaviour
    {
        [Inject (Id = "BulletsContainer")] GameObject _bulletsGameObject;
        [SerializeField] WeaponDescription[] _weaponDescriptions;

        [Inject]
        readonly DI.BulletFactory _bulletFactory;

        [Inject]
        readonly DI.WeaponFactory _weaponFactory;

        private List<Weapon> _weapons;

        [SerializeField] private bool _isFiring;
        public bool IsFiring => _isFiring;

        private void Start()
        {
            _weapons = new List<Weapon>();
            foreach(var weaponDescription in _weaponDescriptions)
            {
                var weapon = _weaponFactory.Create(weaponDescription);
                _weapons.Add(weapon);
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
            var weaponDescription = weapon.GetDescription();
            _bulletFactory.Create(tag, transform.position, Vector2.up, weaponDescription.bulletPrefub);
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

