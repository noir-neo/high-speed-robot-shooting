using System.Collections;
using UnityEngine;

namespace Bullets.BulletImpls
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed;
        [SerializeField] private float _destroyTime;

        public void Fire(Vector3 forward)
        {
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
