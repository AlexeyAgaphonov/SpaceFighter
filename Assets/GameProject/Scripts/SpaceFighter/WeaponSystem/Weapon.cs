using UnityEngine;

namespace SpaceFighter
{
    public class Weapon
    {
        private float _cooldownTimer;
        private WeaponDescription _weaponDescription;

        public Weapon(WeaponDescription weaponDescription) 
        {
            _weaponDescription = weaponDescription;
            _cooldownTimer = _weaponDescription.cooldownAttack;
        }

        public void Update(float dt)
        {
            if (IsReadyToFire())
            {
                return;
            }

            _cooldownTimer -= dt;
            if (_cooldownTimer <= 0f)
            {
                _cooldownTimer = 0f;
            }
        }

        public bool IsReadyToFire()
        {
            return _cooldownTimer <= 0.0f;
        }

        public void Reload()
        {
            _cooldownTimer = _weaponDescription.cooldownAttack;
        }

        public WeaponDescription GetDescription()
        {
            return _weaponDescription;
        }
    }
}
