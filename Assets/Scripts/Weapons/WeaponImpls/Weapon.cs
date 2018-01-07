using UnityEngine;

namespace Weapons.WeaponImpls
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField] private FollowTransform _followTransform;
        public void Configure(Transform root)
        {
            _followTransform.target = root;
        }

        public void Shoot()
        {

        }
    }
}
