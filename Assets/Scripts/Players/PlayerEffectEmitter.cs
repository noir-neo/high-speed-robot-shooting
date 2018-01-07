using UniRx;
using UnityEngine;

namespace Players
{
    public class PlayerEffectEmitter : MonoBehaviour
    {
        [SerializeField] private PlayerCore _playerCore;
        [SerializeField] private ParticleSystem _exploded;
        [SerializeField] private ParticleSystem _damaged;

        void Start()
        {
            _playerCore.Explode
                .Subscribe(_ => _exploded.Play())
                .AddTo(this);
            _playerCore.Damage
                .Subscribe(_ => _damaged.Play())
                .AddTo(this);
        }
    }
}
