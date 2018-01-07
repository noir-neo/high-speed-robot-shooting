using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using Weapons;
using Weapons.WeaponImpls;
using Zenject;

namespace Players
{
    [RequireComponent(typeof(PlayerCore))]
    public class PlayerWeapon : MonoBehaviour
    {
        [SerializeField] private PlayerCore _playerCore;
        [SerializeField] private Transform[] WeaponRoots;
        [SerializeField] private Weapon _weaponPrefab;

        private IWeapon[] _weapons;

        void Start()
        {
            _weapons = WeaponRoots.Select(root =>
            {
                var weapon = Instantiate(_weaponPrefab);
                weapon.Configure(root);
                return weapon;
            }).ToArray();
        }

        [Inject]
        void Initialize(List<IInputEventProvider> inputEventProviders, List<IWeapon> weapons)
        {
            inputEventProviders.Select(x => x.ShootButton(_playerCore.PlayerId))
                .Merge()
                .Where(x => x)
                .Subscribe(Shoot)
                .AddTo(this);
        }

        private void Shoot(bool shoot)
        {
            foreach (var weapon in _weapons)
            {
                weapon.Shoot();
            }
        }
    }
}
