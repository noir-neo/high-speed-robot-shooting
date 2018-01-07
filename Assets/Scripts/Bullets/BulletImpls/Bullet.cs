using System.Collections;
using Damages;
using Players;
using UnityEngine;

namespace Bullets.BulletImpls
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed;
        [SerializeField] private float _destroyTime;
        [SerializeField] private DamageApplier _damageApplier;

        public void Fire(Vector3 forward, PlayerId shooter)
        {
            _damageApplier.Damage.Shooter = shooter;
            _rigidbody.AddForce(forward * _speed, ForceMode.Impulse);
            StartCoroutine(Destroy());
        }

        private IEnumerator Destroy()
        {
            yield return new WaitForSeconds(_destroyTime);
            Destroy(gameObject);
        }
    }
}
