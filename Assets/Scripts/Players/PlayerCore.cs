using System;
using Damages;
using UniRx;
using UnityEngine;

namespace Players
{
    public class PlayerCore : MonoBehaviour, IDamageApplicable
    {
        [SerializeField] private PlayerId _playerId;
        public PlayerId PlayerId => _playerId;
        [SerializeField] private PlayerParameters _parameters;
        public PlayerParameters PlayerParameters => _parameters;

        private readonly IntReactiveProperty _hp = new IntReactiveProperty(0);

        public IObservable<Unit> Explode => _hp.Skip(1).SkipWhile(x => x > 0).AsUnitObservable();

        void Awake()
        {
            _hp.Value = _parameters.Hp;
        }

        public void ApplyDamage(Damage damage)
        {
            if (damage.Shooter == _playerId) return;
            _hp.Value -= damage.Value;
        }
    }
}
