using UnityEngine;

namespace Damages
{
    public class DamageApplier : MonoBehaviour
    {
        [SerializeField] private Damage _damage;

        void OnTriggerEnter(Collider collider)
        {
            foreach (var damageApplicablet in collider.GetComponents<IDamageApplicable>())
            {
                damageApplicablet.ApplyDamage(_damage);
            }
        }
    }
}
