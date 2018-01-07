using Players;
using UnityEngine;
using Bullet = Bullets.BulletImpls.Bullet;

namespace Weapons.WeaponImpls
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private FollowTransform _followTransform;
        [SerializeField] private Transform _muzzle;

        public void Configure(Transform root)
        {
            _followTransform.target = root;
        }

        void IWeapon.Shoot(PlayerId playerId)
        {
            // HACK: Trail 出ちゃうので
            var bullet = Instantiate(_bulletPrefab, _muzzle);
            bullet.transform.SetParent(null);
            bullet.Fire(transform.forward, playerId);
        }
    }
}
