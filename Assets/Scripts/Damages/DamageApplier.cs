using UnityEngine;

namespace Damages
{
    public class DamageApplier : MonoBehaviour
    {
        public Damage Damage;

        void OnTriggerEnter(Collider collider)
        {
            foreach (var damageApplicablet in collider.GetComponents<IDamageApplicable>())
            {
                damageApplicablet.ApplyDamage(Damage);
            }
        }
    }
}
