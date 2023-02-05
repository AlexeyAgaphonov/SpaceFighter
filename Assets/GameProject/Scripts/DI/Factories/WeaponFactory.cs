using UnityEngine;
using Zenject;


namespace DI
{
    public class WeaponFactory : IFactory<SpaceFighter.WeaponDescription, SpaceFighter.Weapon>
    {
        readonly DiContainer _container;

        WeaponFactory(DiContainer container)
        {
            _container = container;
        }

        public SpaceFighter.Weapon Create(SpaceFighter.WeaponDescription weaponDescription)
        {
            return new SpaceFighter.Weapon(weaponDescription);
        }
    }
}
